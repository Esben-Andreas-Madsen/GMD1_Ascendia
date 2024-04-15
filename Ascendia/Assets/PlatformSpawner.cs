using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //Platform spawner script by Esben
    //Keeps track of game platform prefab objects
    public GameObject platformPrefab;
    public float distanceBetweenPlatforms = 5f; 
    public int maxPlatforms = 20; 
    public Transform player;
    public float spawnAheadDistance = 20f; 
    public int maxInitialSpawnAttempts = 100; // Ran into some infinite loop where my ram kept growing. This helped >_>

    private GameObject[] platforms;
    private float lastSpawnPosition;

    void Start()
    {
        platforms = new GameObject[maxPlatforms];
        lastSpawnPosition = player.position.y;
        SpawnInitialPlatforms();
    }

    void Update()
    {
        // Check if the player has moved beyond the last spawned position, then spawn platforms ahead
        if (player.position.y + spawnAheadDistance > lastSpawnPosition)
        {
            SpawnPlatform();
        }
    }

    void SpawnInitialPlatforms()
    {
        int attempts = 0;
        while (lastSpawnPosition < player.position.y + spawnAheadDistance && attempts < maxInitialSpawnAttempts)
        {
            SpawnPlatform();
            attempts++;
        }
    }

    void SpawnPlatform()
    {
        float yPos = lastSpawnPosition + distanceBetweenPlatforms; 

        if (GetActivePlatformCount() >= maxPlatforms)
        {
            RemoveLowestPlatform();
        }

        GameObject platform = Instantiate(platformPrefab, new Vector3(Random.Range(-8f, 8f), yPos, 0f), Quaternion.identity);
        platforms[GetNextPlatformIndex()] = platform;
        lastSpawnPosition = yPos;
    }

    void RemoveLowestPlatform()
    {
        float lowestYPos = float.MaxValue;
        int lowestPlatformIndex = -1;

        // Find the lowest platform
        for (int i = 0; i < maxPlatforms; i++)
        {
            if (platforms[i] != null && platforms[i].transform.position.y < lowestYPos)
            {
                lowestYPos = platforms[i].transform.position.y;
                lowestPlatformIndex = i;
            }
        }

        // Remove the lowest platform
        if (lowestPlatformIndex != -1)
        {
            Destroy(platforms[lowestPlatformIndex]);
            platforms[lowestPlatformIndex] = null;
        }
    }

    int GetNextPlatformIndex()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            if (platforms[i] == null)
            {
                return i;
            }
        }
        //Fallback if for some reason no spots were available
        return Random.Range(0, maxPlatforms);
    }

    int GetActivePlatformCount()
    {
        int count = 0;
        for (int i = 0; i < maxPlatforms; i++)
        {
            if (platforms[i] != null)
            {
                count++;
            }
        }
        return count;
    }
}

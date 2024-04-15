using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float distanceBetweenPlatforms = 5f; // Adjust this to change the distance between platforms
    public int maxPlatforms = 20; // Maximum number of platforms to keep active at once
    public Transform player;
    public float spawnAheadDistance = 20f; // Distance ahead of the player to spawn platforms
    public int maxInitialSpawnAttempts = 100; // Maximum attempts to spawn initial platforms

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
        float yPos = lastSpawnPosition + distanceBetweenPlatforms; // Spawn above the last platform

        // Check if the total number of platforms exceeds the maximum limit
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
        // If no inactive platform is found, return the index of the oldest platform
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

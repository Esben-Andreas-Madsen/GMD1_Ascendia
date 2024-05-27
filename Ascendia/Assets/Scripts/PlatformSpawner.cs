using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float distanceBetweenPlatforms = 5f;
    public int maxPlatforms = 20;
    public Transform player;
    public float spawnAheadDistance = 20f;
    public int maxInitialSpawnAttempts = 100;
    public float minPlatformLength = 1f;
    public float maxPlatformLength = 5f; 

    private GameObject[] platforms;
    private float lastSpawnPosition;
    private int platformCount = 0; 

    void Start()
    {
        platforms = new GameObject[maxPlatforms];
        lastSpawnPosition = player.position.y;
        SpawnInitialPlatforms();
    }

    void Update()
    {
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

        float length = Random.Range(minPlatformLength, maxPlatformLength);
        float xPos = Random.Range(-8f, 8f);
        GameObject platform = Instantiate(platformPrefab, new Vector2(xPos, yPos), Quaternion.identity);

        if (++platformCount % 100 == 0)
        {
            length = 6f;
        }

        platform.transform.localScale = new Vector2(length, platform.transform.localScale.y);

        platforms[GetNextPlatformIndex()] = platform;
        lastSpawnPosition = yPos;
    }

    void RemoveLowestPlatform()
    {
        float lowestYPos = float.MaxValue;
        int lowestPlatformIndex = -1;

        for (int i = 0; i < maxPlatforms; i++)
        {
            if (platforms[i] != null && platforms[i].transform.position.y < lowestYPos)
            {
                lowestYPos = platforms[i].transform.position.y;
                lowestPlatformIndex = i;
            }
        }

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

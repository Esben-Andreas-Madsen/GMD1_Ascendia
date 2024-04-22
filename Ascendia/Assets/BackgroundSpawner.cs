using UnityEngine;
using System.Collections.Generic;

public class BackgroundSpawner : MonoBehaviour
{
    //by Esben
    //Script for generating background panels.
    //Logic works very much like the platform manager keeping track of spawned objects
    //Despawns platforms below certain distance from player
    //Randomly places cloud or wall prefab on left or right
    public GameObject backgroundCloudsDarkPrefab;
    public GameObject backgroundDarkPrefab;
    public float spawnYDistance = 10f;
    public float despawnYDistance = 20f;
    public Transform player;
    public Vector3 leftSpawnPosition = new Vector3(-5.5f, 10f, 0);
    public Vector3 rightSpawnPosition = new Vector3(5.5f, 10f, 0);
    public float spawnOffset = 10f; 

    private float lastSpawnY; 
    private List<GameObject> spawnedBackgrounds = new List<GameObject>();

    void Start()
    {

        lastSpawnY = -30f;

        for (int i = 0; i < 6; i++)
        {
            SpawnBackgrounds();
            lastSpawnY += spawnYDistance;
        }
    }

    void Update()
    {
        if (player.position.y - lastSpawnY >= spawnYDistance)
        {
            SpawnBackgrounds();
            lastSpawnY = player.position.y;
        }

        DespawnBackgrounds();
    }

    void SpawnBackgrounds()
    {
        GameObject leftBackgroundPrefab = Random.Range(0f, 1f) > 0.5f ? backgroundCloudsDarkPrefab : backgroundDarkPrefab;
        GameObject rightBackgroundPrefab = Random.Range(0f, 1f) > 0.5f ? backgroundCloudsDarkPrefab : backgroundDarkPrefab;

        Vector3 leftSpawnPos = leftSpawnPosition + new Vector3(0, lastSpawnY + spawnOffset, 0);
        Vector3 rightSpawnPos = rightSpawnPosition + new Vector3(0, lastSpawnY + spawnOffset, 0);

        // Spawn backgrounds
        GameObject leftBackground = Instantiate(leftBackgroundPrefab, leftSpawnPos, Quaternion.identity);
        GameObject rightBackground = Instantiate(rightBackgroundPrefab, rightSpawnPos, Quaternion.identity);

        spawnedBackgrounds.Add(leftBackground);
        spawnedBackgrounds.Add(rightBackground);
    }

    void DespawnBackgrounds()
    {
        for (int i = spawnedBackgrounds.Count - 1; i >= 0; i--)
        {
            if (player.position.y - spawnedBackgrounds[i].transform.position.y >= despawnYDistance)
            {
                Destroy(spawnedBackgrounds[i]);
                spawnedBackgrounds.RemoveAt(i);
            }
        }
    }
}

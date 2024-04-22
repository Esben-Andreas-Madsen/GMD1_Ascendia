using UnityEngine;
using System.Collections.Generic;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject backgroundCloudsDarkPrefab; // Prefab for clouds dark background sprite
    public GameObject backgroundDarkPrefab; // Prefab for dark background sprite
    public float spawnYDistance = 10f; // Distance the player needs to move vertically before spawning
    public float despawnYDistance = 20f; // Distance below the player to despawn backgrounds
    public Transform player; // Reference to the player's transform
    public Vector3 leftSpawnPosition = new Vector3(-5.5f, 10f, 0); // Position to spawn the left background with an initial offset in y
    public Vector3 rightSpawnPosition = new Vector3(5.5f, 10f, 0); // Position to spawn the right background with an initial offset in y
    public float spawnOffset = 10f; // Additional offset in y for each new background

    private float lastSpawnY; // Y position of the player when the last spawn occurred
    private List<GameObject> spawnedBackgrounds = new List<GameObject>(); // List to keep track of spawned backgrounds

    void Start()
    {
        // Start spawning backgrounds from y = -4
        lastSpawnY = -50f;

        // Spawn the first 6 backgrounds
        for (int i = 0; i < 6; i++)
        {
            SpawnBackgrounds();
            lastSpawnY += spawnYDistance;
        }
    }

    void Update()
    {
        // Check if the player has moved the specified Y distance since the last spawn
        if (player.position.y - lastSpawnY >= spawnYDistance)
        {
            SpawnBackgrounds();
            lastSpawnY = player.position.y;
        }

        // Despawn backgrounds that are far below the player
        DespawnBackgrounds();
    }

    void SpawnBackgrounds()
    {
        // Randomly choose which background to spawn on the left and right
        GameObject leftBackgroundPrefab = Random.Range(0f, 1f) > 0.5f ? backgroundCloudsDarkPrefab : backgroundDarkPrefab;
        GameObject rightBackgroundPrefab = Random.Range(0f, 1f) > 0.5f ? backgroundCloudsDarkPrefab : backgroundDarkPrefab;

        // Calculate spawn positions relative to the player's position, with additional offset in y
        Vector3 leftSpawnPos = leftSpawnPosition + new Vector3(0, lastSpawnY + spawnOffset, 0);
        Vector3 rightSpawnPos = rightSpawnPosition + new Vector3(0, lastSpawnY + spawnOffset, 0);

        // Spawn backgrounds
        GameObject leftBackground = Instantiate(leftBackgroundPrefab, leftSpawnPos, Quaternion.identity);
        GameObject rightBackground = Instantiate(rightBackgroundPrefab, rightSpawnPos, Quaternion.identity);

        // Add spawned backgrounds to the list
        spawnedBackgrounds.Add(leftBackground);
        spawnedBackgrounds.Add(rightBackground);
    }

    void DespawnBackgrounds()
    {
        // Remove backgrounds that are far below the player
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

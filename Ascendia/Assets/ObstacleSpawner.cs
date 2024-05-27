using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Spawns and despawns an obstacle, max 1 at a time

    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnHeight = 30f;
    public float despawnDistance = 100f;

    private GameObject currentObstacle;

    private void Update()
    {
        float despawnHeight = player.position.y - despawnDistance;

        if (currentObstacle == null)
        {
            SpawnObstacle();
        }
        else if (currentObstacle.transform.position.y < despawnHeight)
        {
            Destroy(currentObstacle);
            currentObstacle = null;
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = player.position + new Vector3(Random.Range(-10f, 10f), spawnHeight, 0f);
        currentObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
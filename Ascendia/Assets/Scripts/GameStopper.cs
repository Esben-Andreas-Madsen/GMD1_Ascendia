using System;
using UnityEngine;

public class GameStopper : MonoBehaviour
{
    public Transform player;
    public float startingDistance = 80f;
    public RespawnMenu respawnMenu;

    private Rigidbody2D playerRigidbody2D;
    private float highestYPosition;

    public event Action OnPlayerDeath;

    private void Start()
    {
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        highestYPosition = transform.position.y;

        transform.position = player.position - new Vector3(0f, startingDistance, 0f);
    }

    private void Update()
    {
        if (playerRigidbody2D.velocity.y > 0)
        {
            float newYPosition = player.position.y - startingDistance;
            transform.position = new Vector3(transform.position.x, Mathf.Max(newYPosition, highestYPosition), transform.position.z);

            highestYPosition = Mathf.Max(transform.position.y, highestYPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the collider. Stopping the game.");
            Time.timeScale = 0;
            respawnMenu.ShowRespawnMenu();

            HandlePlayerDeath();
        }
    }

    public void HandlePlayerDeath()
    {
        // Trigger the death event
        Debug.Log("Player has died");
        OnPlayerDeath?.Invoke();
    }
}

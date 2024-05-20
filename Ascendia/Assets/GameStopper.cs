using UnityEngine;

public class GameStopper2D : MonoBehaviour
{
    public Transform player;
    public float startingDistance = 80f;
    public RespawnMenu respawnMenu;

    private Rigidbody2D playerRigidbody2D;
    private float highestYPosition;

    private void Start()
    {
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        highestYPosition = transform.position.y; // Initialize the highest Y position

        // Set the initial position of the GameStopper below the player
        transform.position = player.position - new Vector3(0f, startingDistance, 0f);
    }

    private void Update()
    {
        if (playerRigidbody2D.velocity.y > 0)
        {
            float newYPosition = player.position.y - startingDistance;
            transform.position = new Vector3(transform.position.x, Mathf.Max(newYPosition, highestYPosition), transform.position.z);

            // Update the highest Y position if the GameStopper ascends further
            highestYPosition = Mathf.Max(transform.position.y, highestYPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the collider. Stopping the game.");
            Time.timeScale = 0;
            // Show the respawn menu
            respawnMenu.ShowRespawnMenu();
        }
    }
}

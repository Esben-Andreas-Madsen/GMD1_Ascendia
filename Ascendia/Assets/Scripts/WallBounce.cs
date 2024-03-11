using UnityEngine;

public class WallBounce : MonoBehaviour
{
    //by Esben
    //Make wall collission increase player momentum and bounce back
    //TODO: make it work properly
    [SerializeField] private float bounceForce = 5f;
    [SerializeField] private float horizontalPushForce = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Debug statement

        // Check if the collision is with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Calculate the bounce direction (opposite of the wall's normal)
            Vector2 bounceDirection = -collision.contacts[0].normal;

            // Apply the bounce force
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);

            // Apply horizontal push force
            float pushDirection = Mathf.Sign(bounceDirection.x); // Get the direction of the bounce
            rb.AddForce(new Vector2(pushDirection * horizontalPushForce, 0f), ForceMode2D.Impulse);
        }
    }

}

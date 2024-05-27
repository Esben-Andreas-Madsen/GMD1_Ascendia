using System.Collections;
using UnityEngine;

public class MovingObstacle2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minChangeTime = 1f;
    public float maxChangeTime = 3f;
    public float playerDetectionRange = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChangeDirection());
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minChangeTime, maxChangeTime));
            if (player != null)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (distanceToPlayer <= playerDetectionRange)
                {
                    Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
                    movement = new Vector2(directionToPlayer.x, 0);
                }
                else
                {
                    float randomDirection = Random.Range(-1f, 1f);
                    movement = new Vector2(randomDirection, 0).normalized;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle obstruction logic (e.g., reduce player health, bounce player, etc.)
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reverse direction on hitting a wall
            movement = -movement;
        }
    }
}

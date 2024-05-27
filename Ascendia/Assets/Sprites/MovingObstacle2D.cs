using System.Collections;
using UnityEngine;

//Pair programming
//AI that handles obstacle
//Rotates
public class MovingObstacle2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 100f;
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
        Rotate();
    }

    private void Move()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    private void Rotate()
    {
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            float currentAngle = Mathf.Atan2(rb.transform.up.y, rb.transform.up.x) * Mathf.Rad2Deg;
            float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

            float rotationAmount = Mathf.Sign(angleDifference) * Mathf.Min(rotationSpeed * Time.fixedDeltaTime, Mathf.Abs(angleDifference));
            rb.MoveRotation(rb.rotation + rotationAmount);
        }
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            if (player != null)
            {
                Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
                movement = directionToPlayer;
            }
            yield return new WaitForSeconds(Random.Range(0.25f, 1f));
        }
    }
}

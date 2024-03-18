# Log 3: Development Update

## Updates and Additions


### Player Movement

```
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float baseJumpingPower = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float horizontalInput;
    private bool isJumping;
    private bool isGrounded;
    private float currentSpeed;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");

        if (isJumping && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalInput);
        CheckGrounded();
        Accelerate();

        Debug.Log("Speed is: " + currentSpeed); // Debug statement

    }

    private void MovePlayer(float horizontalInput)
    {
        rb.velocity = new Vector2(horizontalInput * currentSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        float jumpingPower = baseJumpingPower + (currentSpeed / maxSpeed) * baseJumpingPower;
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Accelerate()
    {
        if (Mathf.Abs(horizontalInput) > 0)
        {
            // Accelerate gradually up to the max speed
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.fixedDeltaTime, baseSpeed, maxSpeed);
        }
        else
        {
            // Decelerate gradually when not moving
            if (currentSpeed > baseSpeed)
            {
                currentSpeed = Mathf.Clamp(currentSpeed - (acceleration * 4) * Time.fixedDeltaTime, baseSpeed, maxSpeed);
            }
            else
            {
                currentSpeed = baseSpeed;
            }
        }
    }

}

```

### Camera Movement

```
using UnityEngine;

public class CameraFollow : MonoBehaviour
    //Follow the Players y-axis
{
    public Transform target; // Reference to the player's transform

    private void Update()
    {
        if (target != null)
        {
            // Get the current position of the camera
            Vector3 newPosition = transform.position;

            // Update only the y-coordinate to match the player's y-coordinate
            newPosition.y = target.position.y;

            // Apply the new position to the camera
            transform.position = newPosition;
        }
    }
}

```

### Platform Prefab

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/481ce523-6ba9-41f0-836c-0eefff94474a)

### Platform Colission

```
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Collider2D topCollider;
    public Collider2D bodyCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the top collider when the player enters the body collider
            topCollider.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the top collider when the player leaves the body collider
            topCollider.enabled = true;
        }
    }
}
```

### Sprites

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/28a44246-aa17-47c6-aa5d-f78162e34ad8)

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/aee4c093-0b56-4e43-a30e-fe0e34e04fd9)


# Log 3: Development Update

## Updates and Additions


### Player Movement

The movement for the player is essential for having a decent game, and it takes a lot of tweaking to hit the sweet spot.  
In out movement script we have taken considerations for the following:
- input
- acceleration / deacceleration
- jumping
- ground check

```
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

Our game progresses upwards which is why we created a script that follows only the y-axis of the player.


```
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

```

### Platform Prefab

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/481ce523-6ba9-41f0-836c-0eefff94474a)

### Platform Colission
Unity provides a 2D collision script but it doesn't allow for side-collision which we want.
So we made our own solution instead. 
Our script allows the player to pass through the platforms from sides and underneath whilst being able to land on top.
There could be some slight issues in the future due to the bottom collider being bigger than necessary, but it is also at the same time a way of handling the collision properly based on the trajectory of the player model.
It's done by having two colliders where one is a trigger. The picture below illustrates this:

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/182b98bd-1676-40c5-bddb-c1fdd0c27769)

When entering the blue colider it disables the red one, and when exiting it re-enables it.
It is implementing in the following way:


```
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
```

### Sprites

Finding assets in the asset store would probably be a lot easier than creating your own but we wanted to give it a shot anyways. We create some sprites in Aseprite which is also capable of animating. There were also some sprites we created which resembled keyboard input for an instructions page, but opted out of using those since the main focus is playability on an arcade machine.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/28a44246-aa17-47c6-aa5d-f78162e34ad8)

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/aee4c093-0b56-4e43-a30e-fe0e34e04fd9)


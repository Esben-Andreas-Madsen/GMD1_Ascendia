using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //by Esben
    //Movement for the Player
    //Gradially builds up or down depending on movement input
    //Jump height is based on player momentum
    //Jumping is only possible when grounded
    //Sprite changes depending on ´wether gounded
    [SerializeField] private float baseSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float baseJumpingPower = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Sprite groundedSprite;
    public Sprite jumpingSprite; 

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

        if (isGrounded)
        {
            spriteRenderer.sprite = groundedSprite;
        }
        else
        {
            spriteRenderer.sprite = jumpingSprite;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalInput);
        CheckGrounded();
        Accelerate();
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

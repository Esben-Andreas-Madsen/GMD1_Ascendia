using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //By Esben
    private float horizontal;
    private float speed = 15f;
    private float jumpingPower = 60f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundChack;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChack.position, 0.2f, groundLayer);
    }
}

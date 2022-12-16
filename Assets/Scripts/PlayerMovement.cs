using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Movement Stats
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpPower = 16f;

    // Player State Info
    private float inputHorizontal;
    private bool isFacingRight = true;

    // References to Unity Objects
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        // Read Horizontal Input
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        // Movement methods
        Flip();
        Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // When jump button is released; begin to decrease player velocity
        // Allows the player to jump higher based on how long they hold down the jump button
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void Flip()
    {
        // Flip direction player is facing based on horizontal movement inputs
        if (isFacingRight && inputHorizontal < 0 || !isFacingRight && inputHorizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public bool IsWalking()
    {
        if(inputHorizontal != 0)
        {
            return true;
        }
        return false;
    }
}

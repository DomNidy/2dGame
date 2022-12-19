using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Movement Stats
    [SerializeField] private float speed = 8f;
    [SerializeField] private float speedWalk = 8f;
    [SerializeField] private float speedSprint = 12f;
    [SerializeField] private float jumpPower = 16f;

    // Player State Info
    private float inputHorizontal;
    private bool isFacingRight = true;

    // References to Unity Objects
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Player Input
        PlayerInput();
        

        // Movement methods
        Flip();
        Jump();
        
        // Animate methods
        AnimateMovement();
        AnimateAttack();
        AnimateJump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
    }

    private void PlayerInput()
    {
        // Read Horizontal Input
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedSprint;
        }
        else
        {
            speed = speedWalk;
        }
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

    private void AnimateAttack()
    {
        // Animate attack
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void AnimateMovement()
    {
        animator.SetFloat("PlayerSpeed", Mathf.Abs(inputHorizontal * speed));
    }

    private void AnimateJump()
    {
        if(rb.velocity.y > 0f)
        {
            animator.SetBool("isJumping", true);
        }
        if(IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }

    }

}

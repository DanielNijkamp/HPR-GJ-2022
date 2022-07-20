using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float jumpUpMultiplier = 1f;
    [SerializeField] private float jumpDownMultiplier = 0.5f;
    private bool isFacingRight = true;

    [Header("Movement Parts")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * jumpUpMultiplier);

        }

        Flip();
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //feature
        //if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        //{
          //  rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpDownMultiplier);

        //}
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

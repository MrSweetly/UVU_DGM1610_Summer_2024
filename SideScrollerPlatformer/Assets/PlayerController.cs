using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float moveSpeed = 5f;
    private float jumpingForce = 5.5f;
    private bool doubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        // Jumps
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
                doubleJump = !doubleJump;
            }
        }
    }

    void FixedUpdate()
    {
        // Character movement
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Check if on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
}


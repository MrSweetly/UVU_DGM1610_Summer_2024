using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    // Movement
    private float horizontal;
    private bool isFacingRight = true;
    private bool isSprinting = false;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float SprintModifier = 1.5f;
    
    // Jump
    private bool doubleJump;
    [SerializeField] private float jumpingForce = 5.5f;
    [SerializeField] private Transform groundCheck;
    
    // Wall Jump
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(4f, 8f);
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    
    // Wall Slide
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    
    // Crouch
    private Vector4 normalHeight;
    private bool isCrouching = false;
    [SerializeField] private Transform headCheck;
    [SerializeField] private float headCheckLength;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float CrouchModifier = 0.5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float CrouchHeight = .625f;
    
    // Dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    //Start
    private void Start()
    {
        normalHeight = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        // Dash Check
        if (isDashing)
        {
            return;
        }
        
        // Horizontal Movement
        horizontal = Input.GetAxis("Horizontal");
        
        // Dashing
        if (Input.GetKeyDown(KeyCode.W) && canDash)
        {
            StartCoroutine(Dash());
        }
        
        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || !IsGrounded())
        {
            isSprinting = false;
        }
        
        // Jump
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        
        // Double Jump
        if (Input.GetButtonDown("Jump") && !isCrouching)
        {
            if (IsGrounded() || IsWalled() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
                doubleJump = !doubleJump;
            }
        }
        
        // Crouch
        
        bool isHittingHead = headDetect();
        
        if (Input.GetKeyDown(KeyCode.S) && IsGrounded() || isHittingHead)
        {
            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.S) || !IsGrounded() && !isHittingHead)
        {
            isCrouching = false;
        }
        
        // Wall Slide
        WallSlide();
        
        // Wall Jump
        WallJump();
        
        // Character direction flip
        if (!isWallJumping)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Dashing Check
        if (isDashing)
        {
            return;
        }
        
        // Character movement
        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
        
        // Sprinting
        if (isSprinting)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed * SprintModifier, rb.velocity.y);
        }

        // Crouching
        if (isCrouching)
        {
            transform.localScale = new Vector2(normalHeight.x, CrouchHeight);
            rb.velocity = new Vector2(horizontal * moveSpeed * CrouchModifier, rb.velocity.y);
        }
        else
        {
            transform.localScale = normalHeight;
        }
    }

    
    private bool IsGrounded()
    {
        // Check if on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    private bool IsWalled()
    {
        // Check if on a wall
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    
    private void WallSlide()
    {
        // Wall slide
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        // Wall Jump
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        // Jump Button
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                Flip();
            }
            
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }
    
    // Stop Wall Jump
    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    
    private void Flip()
    {
        // Flip character
        if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
        }
        else
        {
            isFacingRight = !isFacingRight;
            Vector3 currentScale = transform.localScale;
            currentScale.x *= 1;
            transform.localScale = currentScale;
        }
    }

    private bool headDetect()
    {
        // Detect Head
        bool hit = Physics2D.Raycast(headCheck.position, Vector2.up, headCheckLength, groundMask);
        return hit;
    }

    private void OnDrawGizmos()
    {
        // Head Check via Line
        if (headCheck == null)
        {
            return;
        }
        
        Vector2 from = headCheck.position;
        Vector2 to = new Vector2(headCheck.position.x, headCheck.position.y + headCheckLength);
        
        Gizmos.DrawLine(from, to);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float origionalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = origionalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
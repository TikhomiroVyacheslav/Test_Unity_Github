using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private BallChar ball;
    private float jumpForce;
    private bool isDoubleJump;
    private bool isGrounded = false;
    private bool doubleJump;
    public Animator anim;

    private Rigidbody2D rb;
    public float rayDistance = 0.6f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /*private void FixedUpdate()
    {
        CheckGround();
    }*/

    private void Update()
    {
        CheckGround();
        ball = GetComponent<BallChar>();
        jumpForce = ball.jumpForce;
        isDoubleJump = ball.isDoubleJump;
        if (Input.GetButtonDown("Jump"))
        {
            
            if (isGrounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;
                
            }
            else if (!doubleJump && isDoubleJump)
            {
                doubleJump = true;
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    /*private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.7f);
        isGrounded = collider.Length > 1;
    }*/


    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            isGrounded = true;
            anim.SetBool("isGroundedAn", true);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGroundedAn", false);
        }
    }

    /*private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
    }*/
}

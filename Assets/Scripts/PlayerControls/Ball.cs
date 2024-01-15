using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallChar : MonoBehaviour
{
    [Header("HP system")]
    [SerializeField]
    public int lives = 5;
    public int maxLives = 5;
    public Image[] hearts;
    public Sprite aliveHeart;
    public Sprite deadHeart;

    [Header("Character specs")]
    [SerializeField]
    public float speed = 3f;
    public float fastRunMultiplier = 2f;
    public float dashMultiplier = 4f;
    public float dashCooldown = 1.0f;
    public float jumpForce = 5f;
    public float dashDuration = 0.3f;

    [Header("Boosters")]
    [SerializeField]
    public Image[] boosters;
    public bool isDoubleJump = false;
    public bool isFastRun = false;

    [Header("Coins")]
    [SerializeField]
    public int coins = 0;

    [Header("Stamina")]
    [SerializeField]
    public float maxStamina;
    public float stamina;
    public float runStaminaConsumption;
    public float dashStaminaConsumption;
    public float dashStaminaNeed;
    public float staminaRecoveringSpeed;
    public bool staminaConsuming;

    [Header("Movement")]
    [SerializeField]
    public bool isRunning;
    public bool isDashing;
    public bool isGrounded;
    public float rayDistance = 0.6f;
    public string movementCondition;
    public float horizontalInput;
    public Vector3 moveDirection;
    public float dashTimer;
    public Vector3 dashDirection;
    public bool dashCooldowned = true;

    [Header("Movement Conditions")]
    [SerializeField]
    public string IS_RUNNING = "running";
    public string IS_FAST_RUNNING = "fast running";
    public string IS_DASHING = "dashing";
    public string IS_STANDING = "standing";
    public string IS_JUMPING = "jumping";

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
        CheckDirection();
        dashStaminaConsumption = dashDuration * dashStaminaNeed;
    }
        


    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void CheckDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = transform.right * horizontalInput;

    }
}

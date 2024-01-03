using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallChar : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public bool isDoubleJump = false;
    [SerializeField] public bool isFastRun = false;

    [SerializeField] public int lives = 5;
    [SerializeField] public int maxLives = 5;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Image[] boosters;
    [SerializeField] public Sprite aliveHeart;
    [SerializeField] public Sprite deadHeart;

    [SerializeField] public int coins = 0;

    private Rigidbody2D rb;
    public float rayDistance = 0.6f;
    [SerializeField] public bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
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
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    private BallChar ball;
    private float speed;
    [SerializeField] public float horizontalMove;
    public Animator anim;
    [SerializeField] private bool dashing;
    public bool dashCooldowned = true;
    [SerializeField] private float dashCooldown = 1.0f;
    [SerializeField] private int dashSpeed = 4;
    [SerializeField] float horizontalInput;
    public Vector3 dashDir;
    public bool staminaConsuming;
    private StaminaManager staminaManager;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private bool isAttacking;

    [SerializeField] public float testTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        dashing = false;
        /*testTimer = dashDuration;*/
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        ball = GetComponent<BallChar>();
        staminaManager = GetComponent<StaminaManager>();
        speed = ball.speed;
        isAttacking = anim.GetBool("attack");
        Vector3 dir = transform.right * horizontalInput;
        /*if (!ball.isDashing)
        {
            TransformDirection(horizontalInput);
        }*/
        TransformDirection(horizontalInput);

        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift) && ball.isFastRun && ball.isGrounded && !ball.isDashing && ball.runStaminaConsumption < ball.stamina && !isAttacking)
        {
            FastRunFunc(dir);
        }
        /*else if ((Input.GetButton("Horizontal") && Input.GetKeyDown(KeyCode.LeftControl) && !dashing && dashCooldowned) | dashing)
        {
            ball.isDashing = true;
            testTimer = dashDuration;
            DashFunc(dir);
        }*/
        else if (Input.GetButton("Horizontal") && Input.GetKeyDown(KeyCode.LeftControl) && !ball.isDashing && dashCooldowned && ball.dashStaminaNeed < ball.stamina && !isAttacking)
        {
            dashDir = dir;
            ball.isDashing = true;
            testTimer = ball.dashDuration;
        }
        else if (ball.isDashing)
        {
            testTimer -= Time.deltaTime;
        }
        else if (Input.GetButton("Horizontal") && !isAttacking && !ball.isDashing)
        {
            /*ball.isRunning = false;
            ball.isDashing = false;*/
            RunFunc(dir);
        }
        else
        {
            ball.staminaConsuming = false;
            ball.isRunning = false;
            ball.isDashing = false;
            anim.SetInteger("State", 0);
        }
    }


    private void TransformDirection(float horizontalInput)
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void RunFunc(Vector3 dir)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        anim.SetInteger("State", 1);
        anim.SetFloat("Horizontal_move", horizontalMove);
    }

    private void FastRunFunc(Vector3 dir)
    {
        ball.isRunning = true;
        ball.staminaConsuming = true;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * 2 * Time.deltaTime);
        anim.SetInteger("State", 1);
        anim.SetFloat("Horizontal_move", horizontalMove);
    }

    /*private void DashFunc(Vector3 dir)
    {
        ball.staminaConsuming = true;
        StartCoroutine(DashDuration(dir));
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dashDir, speed * dashSpeed * Time.deltaTime);
        anim.SetInteger("State", 1);
        anim.SetFloat("Horizontal_move", horizontalMove);
    }*/

    /*private void DashFunc(Vector3 dir)
    {
        StartCoroutine(DashDuration(dir));
        ball.staminaConsuming = true;
        StartCoroutine(DashDuration(dir));
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dashDir, speed * dashSpeed * Time.deltaTime);
        anim.SetInteger("State", 1);
        anim.SetFloat("Horizontal_move", horizontalMove);
    }*/

    /*private IEnumerator DashDuration(Vector3 dir)
    {
        if (!dashing)
        {
            dashDir = dir;
        }
        dashing = true;
        ball.staminaConsuming = true;
        while (testTimer > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dashDir, speed * dashSpeed * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        dashing = false;
        ball.staminaConsuming = false;
        dashCooldowned = false;
        yield return new WaitForSeconds(dashCooldown);
        dashCooldowned = true;
    }*/

    /*private IEnumerator DashDuration(Vector3 dir)
    {
        if (!dashing)
        {
            dashDir = dir;
        }
        dashing = true;
        ball.staminaConsuming = true;
        yield return new WaitForSeconds(dashDuration);
        dashing = false;
        ball.staminaConsuming = false;
        dashCooldowned = false;
        yield return new WaitForSeconds(dashCooldown);
        dashCooldowned = true;
    }*/
}
 
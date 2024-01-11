using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    [SerializeField] private BallChar ball;
    [SerializeField] private Animator anim;
    [SerializeField] private Run run;

    private float speed;
    private bool isAttacking;
    private float horizontalMove;
    [SerializeField] private Vector3 dashDir;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private float dashCooldown = 1.0f;
    [SerializeField] private float dashDuration = 0.3f;
    [SerializeField] private bool dashing;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        ball = GetComponent<BallChar>();
        run = GetComponent<Run>();
        speed = ball.speed;
        isAttacking = anim.GetBool("attack");
        /*Vector3 dir = transform.right * horizontalInput;*/
        if (run.testTimer > 0)
        {
            DashFunc(run.dashDir);
        }
        else if (run.testTimer < 0)
        {
            StartCoroutine(DashDuration());
            ball.isDashing = false;
            ball.staminaConsuming = false;
        }
    }

    private void DashFunc(Vector3 dir)
    {
        ball.staminaConsuming = true;
        /*StartCoroutine(DashDuration(dir));*/
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * dashSpeed * Time.deltaTime);
        anim.SetInteger("State", 1);
        anim.SetFloat("Horizontal_move", horizontalMove);
    }

    private IEnumerator DashDuration()
    {
        /*if (!dashing)
        {
            dashDir = dir;
        }*/
        if (ball.isDashing)
        {
            run.dashCooldowned = false;
            yield return new WaitForSeconds(dashCooldown);
            run.dashCooldowned = true;
        }
    }
}

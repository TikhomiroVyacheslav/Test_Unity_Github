using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    private BallChar ball;
    private float speed;
    private float horizontalMove;
    public Animator anim;
    private float dash_counter;
    [SerializeField] private Jump jump;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private bool isAttacking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        ball = GetComponent<BallChar>();
        speed = ball.speed;
        isAttacking = anim.GetBool("attack");
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift) && ball.isFastRun && ball.isGrounded && dash_counter <= 0 * Time.deltaTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * 2 * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        else if (Input.GetButton("Horizontal") && Input.GetKeyDown(KeyCode.LeftControl) && dash_counter <= 0 * Time.deltaTime)
        {
            dash_counter = 70 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * 4 * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        else if (Input.GetButton("Horizontal") && !isAttacking && dash_counter <= 0 * Time.deltaTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        else if (dash_counter > 0 * Time.deltaTime)
        {
            dash_counter -= 1 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * 4 * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        else
            anim.SetInteger("State", 0);
    }
}
 
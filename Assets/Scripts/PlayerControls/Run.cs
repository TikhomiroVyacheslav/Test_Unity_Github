using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    private BallChar ball;
    private float speed;
    private float horizontalMove;
    public Animator anim;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ball = GetComponent<BallChar>();
        speed = ball.speed;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift) && ball.isFastRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * 2 * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        else if (Input.GetButton("Horizontal"))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            anim.SetInteger("State", 1);
            anim.SetFloat("Horizontal_move", horizontalMove);
        }
        else
            anim.SetInteger("State", 0);
    }
}
 
using UnityEngine;

public class Run : MonoBehaviour
{
    private BallChar ball;
    private float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        ball = GetComponent<BallChar>();
        speed = ball.speed;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift))
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * 2 * Time.deltaTime);
        else if (Input.GetButton("Horizontal"))
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
}
        
            
            

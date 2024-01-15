using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BallChar ball;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if ( ball.movementCondition != ball.IS_DASHING)
            TransformDirection();
    }

    private void TransformDirection()
    {
        if (ball.horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (ball.horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void RunAnim()
    {
        anim.SetInteger("State", 1);
        anim.SetFloat("Horizontal_move", ball.horizontalInput);
    }

    public void IdleAnim()
    {
        anim.SetInteger("State", 0);
    }
}

using UnityEngine;

public class Run2 : MonoBehaviour
{
    [SerializeField] private BallChar ball;
    [SerializeField] private AnimationManager animationManager;

    void Update()
    {
        ball = GetComponent<BallChar>();
        animationManager = GetComponent<AnimationManager>();
        if (ball.movementCondition == ball.IS_RUNNING)
            RunFunc(ball.speed, ball.moveDirection);
        else if (ball.movementCondition == ball.IS_FAST_RUNNING)
            FastRunFunc(ball.speed, ball.moveDirection, ball.fastRunMultiplier);
    }

    public void RunFunc(float speed, Vector3 dir)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        animationManager.RunAnim();
    }

    public void FastRunFunc(float speed, Vector3 dir, float fastRunMultiplier)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * fastRunMultiplier * Time.deltaTime);
        animationManager.RunAnim();
    }
}

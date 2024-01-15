using System.Collections;
using UnityEngine;

public class Dash2 : MonoBehaviour
{
    [SerializeField] private BallChar ball;
    [SerializeField] private AnimationManager animationManager;


    void Update()
    {
        ball = GetComponent<BallChar>();
        animationManager = GetComponent<AnimationManager>();
        if (ball.dashTimer > 0)
        {
            DashFunc(ball.dashDirection);
        }
        else if (ball.dashTimer < 0)
        {
            StartCoroutine(DashCooldown());
            ball.movementCondition = ball.IS_STANDING;
        }
    }

    private void DashFunc(Vector3 dir)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, ball.speed * ball.dashMultiplier * Time.deltaTime);
        animationManager.RunAnim();
    }

    private IEnumerator DashCooldown()
    {
        if (ball.movementCondition == ball.IS_DASHING)
        {
            ball.dashCooldowned = false;
            yield return new WaitForSeconds(ball.dashCooldown);
            ball.dashCooldowned = true;
        }
    }
}

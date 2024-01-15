using UnityEngine;


public class MoveManager : MonoBehaviour
{
    [SerializeField] private BallChar ball;
    [SerializeField] private Run2 run;
    [SerializeField] private AnimationManager animationManager;

    void Update()
    {
        ball = GetComponent<BallChar>();
        animationManager = GetComponent<AnimationManager>();
        if (Input.GetButton("Horizontal") && ball.movementCondition != ball.IS_DASHING)
        {
            if (Input.GetKey(KeyCode.LeftShift) && ball.isGrounded && ball.runStaminaConsumption < ball.stamina)
                ball.movementCondition = ball.IS_FAST_RUNNING;
            else if (Input.GetKeyDown(KeyCode.LeftControl) && ball.dashCooldowned && ball.dashStaminaConsumption < ball.stamina)
            {
                ball.movementCondition = ball.IS_DASHING;
                ball.dashTimer = ball.dashDuration;
                ball.dashDirection = ball.moveDirection;
            }   
            else
                ball.movementCondition = ball.IS_RUNNING;
        }
        else if (ball.movementCondition == ball.IS_DASHING)
            ball.dashTimer -= Time.deltaTime;
        else
        {
            ball.movementCondition = ball.IS_STANDING;
            animationManager.IdleAnim();
        }
    }
}

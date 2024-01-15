using UnityEngine;
using UnityEngine.UI;

public class StaminaManager2 : MonoBehaviour
{
    public BallChar ball;
    public Image staminaBar;
    public Image staminaBarMax;

    void Update()
    {
        ball = GetComponent<BallChar>();
        float maxStamina = ball.maxStamina;
        float stamina = ball.stamina;
        float staminaRecoveringSpeed = ball.staminaRecoveringSpeed;
        StaminaBar(maxStamina, stamina);
        if (ball.movementCondition == ball.IS_STANDING | ball.movementCondition == ball.IS_RUNNING)
        {
            StaminaRecovery(maxStamina, stamina, staminaRecoveringSpeed);
        }
        else if (ball.movementCondition == ball.IS_FAST_RUNNING)
        {
            StaminaConsumption(stamina, ball.runStaminaConsumption);
        }
        else if (ball.movementCondition == ball.IS_DASHING)
        {
            StaminaConsumption(stamina, ball.dashStaminaNeed);
        }
    }

    public void StaminaBar(float maxStamina, float stamina)
    {
        staminaBarMax.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxStamina * 2);
        staminaBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, stamina * 2);
    }

    public void StaminaRecovery(float maxStamina, float stamina, float staminaRecoveringSpeed)
    {
        if (stamina < maxStamina)
        {
            ball.stamina = stamina + staminaRecoveringSpeed * Time.deltaTime;
        }
    }

    public void StaminaConsumption(float stamina, float consumption)
    {
        ball.stamina = stamina - consumption * Time.deltaTime;
    }
}

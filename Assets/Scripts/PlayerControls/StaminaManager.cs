using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
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
        if (!ball.staminaConsuming)
        {
            StaminaRecovery(maxStamina, stamina, staminaRecoveringSpeed);
        }
        else if (ball.isRunning)
        {
            StaminaConsumption(stamina, ball.runStaminaConsumption);
        }
        else if (ball.isDashing)
        {
            StaminaConsumption(stamina, ball.dashStaminaConsumption);
        }
    }

    public void StaminaBar(float maxStamina, float stamina)
    {
        staminaBarMax.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxStamina*2);
        staminaBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, stamina*2);
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

    /*public void StaminaConsumptionFunc()
    {
        staminaConsuming = true;
    }*/

    /*private IEnumerator StaminaConsumption(float stamina, float duration, float consumption)
    {
        staminaConsuming = true;
        ball.stamina = stamina - consumption;
        yield return new WaitForSeconds(duration);
        staminaConsuming = false;
    }*/
}

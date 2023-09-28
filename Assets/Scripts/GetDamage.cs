using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public BallChar ball;

    private void Update()
    {
        if (ball.lives < 1)
            ball.lives = ball.maxLives;
        CheckOutOfWorldDamage();
        HeartManager();
    }

    private void Respawn()
    {
        transform.position = new Vector3(-5.11499977f, -1.37600005f, -0.023249682f);
    }

    private void CheckOutOfWorldDamage()
    {
        if (transform.position.y < -5f)
        {
            ball.lives -= 1;
            Respawn();
        }
    }

    private void HeartManager()
    {
        for (int i = 0; i < ball.hearts.Length; i++)
        {
            if (i < ball.lives)
                ball.hearts[i].sprite = ball.aliveHeart;
            else
                ball.hearts[i].sprite = ball.deadHeart;
            if (i < ball.maxLives)
                ball.hearts[i].enabled = true;
            else
                ball.hearts[i].enabled = false;
        }
    }
}

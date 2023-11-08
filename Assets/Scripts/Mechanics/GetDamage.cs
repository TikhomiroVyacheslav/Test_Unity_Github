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
        HeartManager();
    }

    private void Respawn()
    {
        transform.position = new Vector3(-5.11499977f, -1.37600005f, -0.023249682f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DedZone"))
        {
            if (ball.isDoubleJump)
                SpawnJumpBooster();
            if (ball.isFastRun)
                SpawnSpeedBooster();
            ball.lives -= 1;
            ball.isDoubleJump = false;
            ball.isFastRun = false;
            Respawn();
        }
    }
    //private void CheckOutOfWorldDamage()
    //{
        
    //    if (transform.position.y < -5f)
    //    {
    //        if (ball.isDoubleJump)
    //            SpawnJumpBooster();
    //        if (ball.isFastRun)
    //            SpawnSpeedBooster();
    //        ball.lives -= 1;
    //        ball.isDoubleJump = false;
    //        ball.isFastRun = false;
    //        Respawn();
    //    }
    //}

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

    private void SpawnJumpBooster()
    {
        Instantiate(Resources.Load("Boosters/JumpBooster"), new Vector3(-3.0f, -1.2f, 0), Quaternion.identity);
        
    }

    private void SpawnSpeedBooster()
    {
        Instantiate(Resources.Load("Boosters/SpeedBooster"), new Vector3(4.4f, 0.9f, 0), Quaternion.identity);

    }
}

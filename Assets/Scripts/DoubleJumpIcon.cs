using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJumpIcon : MonoBehaviour
{
    public BallChar ball;
    
    void Update()
    {
        if (ball.isDoubleJump)
            ball.boosters[0].enabled = true;
        else
            ball.boosters[0].enabled = false;
    }
}

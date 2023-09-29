using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastRunIcon : MonoBehaviour
{
    public BallChar ball;
    
    void Update()
    {
        if (ball.isFastRun)
            ball.boosters[1].enabled = true;
        else
            ball.boosters[1].enabled = false;
    }
}

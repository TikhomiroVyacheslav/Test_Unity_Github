using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCounter : MonoBehaviour
{
    [SerializeField] private Text Lives;
    [SerializeField] private BallChar ball;

    void Update()
    {
        Lives.text = "HP: " + ball.lives.ToString();
    }

}

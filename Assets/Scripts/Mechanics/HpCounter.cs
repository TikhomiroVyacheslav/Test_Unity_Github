using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private BallChar ball;

    void Update()
    {
        text.text = "HP: " + ball.lives.ToString();
    }

}

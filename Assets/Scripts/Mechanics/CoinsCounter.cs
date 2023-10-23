using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text CoinsCounterNadpis;
    [SerializeField] private BallChar ball;

    void Update()
    {
        CoinsCounterNadpis.text = "Coins: " + ball.coins.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallChar : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public bool isDoubleJump = true;

    [SerializeField] public int lives = 5;
    [SerializeField] public int maxLives = 5;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite aliveHeart;
    [SerializeField] public Sprite deadHeart;
}

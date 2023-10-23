using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    public BallChar ball;
    public CoinValue CoinValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Booster"))
        {
            Destroy(collision.gameObject);
            ball.isDoubleJump = true;
        }
        else if (collision.CompareTag("SpeedBooster"))
        {
            Destroy(collision.gameObject);
            ball.isFastRun = true;
        }
        else if (collision.CompareTag("Coins"))
        {
            CoinValue = collision.gameObject.GetComponent <CoinValue>();
            Destroy(collision.gameObject);
            ball.coins += CoinValue.value;
        }
    }
}

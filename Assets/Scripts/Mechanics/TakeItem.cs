using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    public BallChar ball;
    //public CoinValue CoinValue;
    private int coins;
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
            //CoinValue = collision.gameObject.GetComponent <CoinValue>();
            coins = collision.gameObject.GetComponent<CoinValue>().value;
            Destroy(collision.gameObject);
            //Destroy(collision.gameObject.transform.parent.gameObject);
            //ball.coins += CoinValue.value;
            ball.coins += coins;
        }
    }
}

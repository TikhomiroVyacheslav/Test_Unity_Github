using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunduk_Open : MonoBehaviour
{

    [SerializeField] public Animator anim;
    [SerializeField] public GameObject eForChundick;
    [SerializeField] public GameObject Coin;
    private bool chundickEntered;
    private Rigidbody2D rb;



    void Update()
    {
        if (chundickEntered == true && anim.GetBool("Chest_opened") == false)
            eForChundick.SetActive(true);
        else 
            eForChundick.SetActive(false);
        if (Input.GetKeyDown(KeyCode.E) && chundickEntered == true)
        {
            anim.SetBool("Chest_opened", true);
           
            GameObject newObject = Instantiate(Coin, transform.localPosition + new Vector3(1.5f, 0.5f, 0.0f), Quaternion.identity);
            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // € бл€ хз что значат эта корутина и иенумератор, но C# ругалс€ когда был цикл фор в UPdate, поэтому так надо было
                {
                    StartCoroutine(RepeatCode(4));
                }

                IEnumerator RepeatCode(int repetitions)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        GameObject newObject = Instantiate(Coin, transform.localPosition + new Vector3(1.5f, 0.5f, 0.0f), Quaternion.identity);
                        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
                        rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
                        rb.AddForce(transform.right * Random.Range(-3, +3), ForceMode2D.Impulse);

                        yield return new WaitForSeconds(0.5f); //∆дем 0,5 сек
                     }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            chundickEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chundickEntered = false;
    }
}

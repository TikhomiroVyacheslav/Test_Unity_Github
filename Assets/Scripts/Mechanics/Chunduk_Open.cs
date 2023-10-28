using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunduk_Open : MonoBehaviour
{

    [SerializeField] public Animator anim;
    [SerializeField] public GameObject eForChundick;
    [SerializeField] public GameObject Coin20;
    private bool chundickEntered;



    void Update()
    {
        if (chundickEntered == true && anim.GetBool("Chest_opened") == false)
            eForChundick.SetActive(true);
        else 
            eForChundick.SetActive(false);
        if (Input.GetKeyDown(KeyCode.E) && chundickEntered == true)
        {
            anim.SetBool("Chest_opened", true);
            GameObject newObject = Instantiate(Coin20, new Vector3(-7.86493778f, -0.429215103f, 0), Quaternion.identity);
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

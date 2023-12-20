
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attack", true);
        }
        else 
        {
            anim.SetBool("attack", false);
        }
    }
}

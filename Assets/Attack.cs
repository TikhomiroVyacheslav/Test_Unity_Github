
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public bool isAttacking = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack_func();
        anim.SetBool("attack", isAttacking);
    }

    private void Attack_func()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
        }
    }

    private void Attack_false()
    {
        isAttacking = false;
    }
}

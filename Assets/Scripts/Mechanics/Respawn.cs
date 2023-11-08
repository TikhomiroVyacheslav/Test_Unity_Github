
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public BallChar ball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DedZone"))
            transform.position = new Vector3(-5.11499977f, -1.37600005f, -0.023249682f);
    }
}

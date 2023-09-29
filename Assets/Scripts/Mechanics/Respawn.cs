using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5f)
            transform.position = new Vector3(-5.11499977f, -1.37600005f, -0.023249682f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5f)
            transform.position = new Vector3(-5f, -1.5f, 0);
    }
}

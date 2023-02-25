using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugNameCollider : MonoBehaviour
{
    public bool check = false;
    private void OnTriggerEnter(Collider other)
    {
        if (check)
            Debug.Log("Tigger Object: " + transform.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (check)
            Debug.Log("Collision Object:" + transform.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public bool onTrigger = true;

    void OnTriggerEnter(Collider other)
    {
        onTrigger = false;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = true;
    }

    public bool isSpaceAvailable()
    {
        return onTrigger;
    }
}

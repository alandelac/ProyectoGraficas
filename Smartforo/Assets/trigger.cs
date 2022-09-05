using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public bool onTrigger = true;

    void OnTriggerEnter(Collider other)
    {
        onTrigger = false;
        print("haciendo contacto");
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = true;
        print("dejando de hacer contacto");
    }

    bool isSpaceAvailable()
    {
        return onTrigger;
    }

    public string pruebaString()
    {
        return "string de prueba";
    }
}

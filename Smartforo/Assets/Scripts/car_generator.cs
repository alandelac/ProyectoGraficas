using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_generator : MonoBehaviour
{
    public GameObject[] car;
    private Vector3 street1_lane1_forward;


    // myVector = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        GameObject carro = car[0];
        street1_lane1_forward = new Vector3 (40.0f, -0.66f, -180.0f);
        Instantiate(carro, street1_lane1_forward, Quaternion.Euler(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_generator : MonoBehaviour
{
    public GameObject[] car;
    private GameObject newObj;
    private Vector3 street1Lane0;
    private Vector3 street1Lane1;
    private Vector3 street2Lane0;
    private Vector3 street2Lane1;
    private Vector3 street3Lane0;
    private Vector3 street3Lane1;
    private Vector3 street4Lane0;
    private Vector3 street4Lane1;

    public GameObject[] triggers;
    private GameObject st1_lane1_trigger;

    void Start()
    {
        GameObject carro_st1 = car[0];
        GameObject carro_st2 = car[1];
        GameObject carro_st3 = car[2];
        GameObject carro_st4 = car[3];

        GameObject st1_lane1_trigger = triggers[0];

        street1Lane0 = new Vector3 (40.0f, -0.66f, -180.0f);
        street1Lane1 = new Vector3 (50.0f, -0.66f, -180.0f);
        street2Lane0 = new Vector3 (30f, -0.66f, 88.0f);
        street2Lane1 = new Vector3 (20.0f, -0.66f, 88.0f);
        street3Lane0 = new Vector3 (200.0f, -0.66f, -53.0f);
        street3Lane1 = new Vector3 (200.0f, -0.66f, -43.0f);
        street4Lane0 = new Vector3 (-115f, -0.66f, -63.0f);
        street4Lane1 = new Vector3 (-115f, -0.66f, -73.0f);

        newObj = Instantiate(carro_st1, street1Lane0, Quaternion.Euler(0, 180, 0)) as GameObject;
        Instantiate(carro_st2, street2Lane1, Quaternion.Euler(0, 180, 0));

        Debug.Log("el nombre es:");
        Debug.Log(st1_lane1_trigger.name);

    }

    void Update()
    {
        Debug.Log(st1_lane1_trigger.GetComponent<trigger>().pruebaString());
    }

}

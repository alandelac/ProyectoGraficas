using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_generator : MonoBehaviour
{
    private Vector3 street1Lane0;
    private Vector3 street1Lane1;
    private Vector3 street2Lane0;
    private Vector3 street2Lane1;
    private Vector3 street3Lane0;
    private Vector3 street3Lane1;
    private Vector3 street4Lane0;
    private Vector3 street4Lane1;

    private trigger st1_lane0_trigger;
    private trigger st1_lane1_trigger;
    private trigger st2_lane0_trigger;
    private trigger st2_lane1_trigger;
    private trigger st3_lane0_trigger;
    private trigger st3_lane1_trigger;
    private trigger st4_lane0_trigger;
    private trigger st4_lane1_trigger;

    private bool isWaiting_st1_lane0;
    private bool isWaiting_st1_lane1;
    private bool isWaiting_st2_lane0;
    private bool isWaiting_st2_lane1;
    private bool isWaiting_st3_lane0;
    private bool isWaiting_st3_lane1;
    private bool isWaiting_st4_lane0;
    private bool isWaiting_st4_lane1;

    private GameObject carro_st1;
    private GameObject carro_st2;
    private GameObject carro_st3;
    private GameObject carro_st4;

    private GameObject[] carList;
    private Vector3[] streetList;
    bool[] isWaitingArr = new bool[8];
    public trigger[] triggerList;
    int minTime = 4;
    int maxTime = 8;

    private List<GameObject> carList_st1;
    private List<GameObject> carList_st2;
    private List<GameObject> carList_st3;
    private List<GameObject> carList_st4;

    void Start()
    {
        carList_st1 = new List<GameObject>();

        isWaiting_st1_lane0 = false;
        isWaiting_st1_lane1 = false;
        isWaiting_st2_lane0 = false;
        isWaiting_st2_lane1 = false;
        isWaiting_st3_lane0 = false;
        isWaiting_st3_lane1 = false;
        isWaiting_st4_lane0 = false;
        isWaiting_st4_lane1 = false;

        street1Lane0 = new Vector3 (40.0f, -0.66f, -208.0f);
        street1Lane1 = new Vector3 (50.0f, -0.66f, -208.0f);
        street2Lane0 = new Vector3 (30f, -0.66f, 91.0f);
        street2Lane1 = new Vector3 (20.0f, -0.66f, 91.0f);
        street3Lane0 = new Vector3 (186.0f, -0.66f, -53.0f);
        street3Lane1 = new Vector3 (186.0f, -0.66f, -43.0f);
        street4Lane0 = new Vector3 (-115f, -0.66f, -63.0f);
        street4Lane1 = new Vector3 (-115f, -0.66f, -73.0f);

        st1_lane0_trigger = triggerList[0];
        st1_lane1_trigger = triggerList[1];
        st2_lane0_trigger = triggerList[2];
        st2_lane1_trigger = triggerList[3];
        st3_lane0_trigger = triggerList[4];
        st3_lane1_trigger = triggerList[5];
        st4_lane0_trigger = triggerList[6];
        st4_lane1_trigger = triggerList[7];

        carro_st1 = (Resources.Load ("Prefabs/Car_1") as GameObject);
        carro_st2 = (Resources.Load ("Prefabs/Car_2") as GameObject);
        carro_st3 = (Resources.Load ("Prefabs/Car_3") as GameObject);
        carro_st4 = (Resources.Load ("Prefabs/Car_4") as GameObject);
    }

    void Update()
    {
        if (st1_lane0_trigger.isSpaceAvailable() && isWaiting_st1_lane0 == false)
        {
            isWaiting_st1_lane0 = true;
            StartCoroutine(waitForCar_st1_lane0());
        }

        if (st1_lane1_trigger.isSpaceAvailable() && isWaiting_st1_lane1 == false)
        {
            isWaiting_st1_lane1 = true;
            StartCoroutine(waitForCar_st1_lane1());
        }

        if (st2_lane0_trigger.isSpaceAvailable() && isWaiting_st2_lane0 == false)
        {
            isWaiting_st2_lane0 = true;
            StartCoroutine(waitForCar_st2_lane0());
        }

        if (st2_lane1_trigger.isSpaceAvailable() && isWaiting_st2_lane1 == false)
        {
            isWaiting_st2_lane1 = true;
            StartCoroutine(waitForCar_st2_lane1());
        }


        if (st3_lane0_trigger.isSpaceAvailable() && isWaiting_st3_lane0 == false)
        {
            isWaiting_st3_lane0 = true;
            StartCoroutine(waitForCar_st3_lane0());
        }

        if (st3_lane1_trigger.isSpaceAvailable() && isWaiting_st3_lane1 == false)
        {
            isWaiting_st3_lane1 = true;
            StartCoroutine(waitForCar_st3_lane1());
        }

        if (st4_lane0_trigger.isSpaceAvailable() && isWaiting_st4_lane0 == false)
        {
            isWaiting_st4_lane0 = true;
            StartCoroutine(waitForCar_st4_lane0());
        }

        if (st4_lane1_trigger.isSpaceAvailable() && isWaiting_st4_lane1 == false)
        {
            isWaiting_st4_lane1 = true;
            StartCoroutine(waitForCar_st4_lane1());
        }

        if (carList_st1.Count != 0)
        {
            print(carList_st1.Count);
            // StartCoroutine(car_stop);
        }


    }

    // private IEnumerator car_stop()
    // {
    //     yield return new WaitForSeconds(5f);
    //     // for (int i=0; i < carList_st1.Count; i++)
    //     // {
    //     //     carList_st1[i].stop();
    //     // }
    // }

    private IEnumerator waitForCar_st1_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        // Instantiate(carro_st1, street1Lane0, Quaternion.Euler(0, 0, 0));
        GameObject newCar_st1 = Instantiate(carro_st1, street1Lane0, Quaternion.Euler(0, 0, 0));
        carList_st1.Add(newCar_st1);
        isWaiting_st1_lane0 = false;
    }

    private IEnumerator waitForCar_st1_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st1, street1Lane1, Quaternion.Euler(0, 0, 0));
        isWaiting_st1_lane1 = false;
    }

    private IEnumerator waitForCar_st2_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st2, street2Lane0, Quaternion.Euler(0, 180, 0));
        isWaiting_st2_lane0 = false;
    }

    private IEnumerator waitForCar_st2_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st2, street2Lane1, Quaternion.Euler(0, 180, 0));
        isWaiting_st2_lane1 = false;
    }

    private IEnumerator waitForCar_st3_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st3, street3Lane0, Quaternion.Euler(0, 270, 0));
        isWaiting_st3_lane0 = false;
    }

    private IEnumerator waitForCar_st3_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st3, street3Lane1, Quaternion.Euler(0, 270, 0));
        isWaiting_st3_lane1 = false;
    }

    private IEnumerator waitForCar_st4_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st4, street4Lane0, Quaternion.Euler(0, 90, 0));
        isWaiting_st4_lane0 = false;
    }

    private IEnumerator waitForCar_st4_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        Instantiate(carro_st4, street4Lane1, Quaternion.Euler(0, 90, 0));
        isWaiting_st4_lane1 = false;
    }
}

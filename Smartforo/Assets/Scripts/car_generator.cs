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

    private GameObject car1;
    private GameObject car2;
    private GameObject car3;
    private GameObject car4;
    private GameObject car5;
    private GameObject carroPrueba;

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

    GameObject[] prefabCars = new GameObject[4];


    void Start()
    {
        carList_st1 = new List<GameObject>();
        carList_st2 = new List<GameObject>();
        carList_st3 = new List<GameObject>();
        carList_st4 = new List<GameObject>();

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

        car1 = (Resources.Load ("Prefabs/Car1") as GameObject);
        car2 = (Resources.Load ("Prefabs/Car2") as GameObject);
        car3 = (Resources.Load ("Prefabs/Car3") as GameObject);
        car4 = (Resources.Load ("Prefabs/Car4") as GameObject);
        car5 = (Resources.Load ("Prefabs/Car5") as GameObject);
        
        prefabCars[0] = car1;
        prefabCars[1] = car2;
        prefabCars[2] = car3;
        prefabCars[3] = car4;
        prefabCars[4] = car5;
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
    }

    private GameObject randomCarModel()
    {
        float randomNumber = Random.Range(0, 4);
        return prefabCars[(int)randomNumber];
    }

    private IEnumerator waitForCar_st1_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st1 = Instantiate(randomCarModel(), street1Lane0, Quaternion.Euler(0, 0, 0));
        newCar_st1.AddComponent<st1_wayCon>();
        carList_st1.Add(newCar_st1);
        isWaiting_st1_lane0 = false;
    }

    private IEnumerator waitForCar_st1_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st1_1 = Instantiate(randomCarModel(), street1Lane1, Quaternion.Euler(0, 0, 0));
        newCar_st1_1.AddComponent<st1_wayCon>();
        carList_st1.Add(newCar_st1_1);
        isWaiting_st1_lane1 = false;
    }

    private IEnumerator waitForCar_st2_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st2 = Instantiate(randomCarModel(), street2Lane0, Quaternion.Euler(0, 180, 0));
        newCar_st2.AddComponent<st2_wayCon>();
        carList_st2.Add(newCar_st2);
        isWaiting_st2_lane0 = false;
    }

    private IEnumerator waitForCar_st2_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st2_1 = Instantiate(randomCarModel(), street2Lane1, Quaternion.Euler(0, 180, 0));
        newCar_st2_1.AddComponent<st2_wayCon>();
        carList_st2.Add(newCar_st2_1);
        isWaiting_st2_lane1 = false;
    }

    private IEnumerator waitForCar_st3_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st3 = Instantiate(randomCarModel(), street3Lane0, Quaternion.Euler(0, 270, 0));
        newCar_st3.AddComponent<st3_wayCon>();
        carList_st3.Add(newCar_st3);
        isWaiting_st3_lane0 = false;
    }

    private IEnumerator waitForCar_st3_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st3_1 = Instantiate(randomCarModel(), street3Lane1, Quaternion.Euler(0, 270, 0));
        newCar_st3_1.AddComponent<st3_wayCon>();
        carList_st3.Add(newCar_st3_1);
        isWaiting_st3_lane1 = false;
    }

    private IEnumerator waitForCar_st4_lane0()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st4 = Instantiate(randomCarModel(), street4Lane0, Quaternion.Euler(0, 90, 0));
        newCar_st4.AddComponent<st4_wayCon>();
        carList_st4.Add(newCar_st4);
        isWaiting_st4_lane0 = false;
    }

    private IEnumerator waitForCar_st4_lane1()
    {
        float randomSeconds = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomSeconds);
        GameObject newCar_st4_1 = Instantiate(randomCarModel(), street4Lane1, Quaternion.Euler(0, 90, 0));
        newCar_st4_1.AddComponent<st4_wayCon>();
        carList_st4.Add(newCar_st4_1);
        isWaiting_st4_lane1 = false;
    }

    public List<GameObject> getList_st1()
    {
        return this.carList_st1;
    }

    public List<GameObject> getList_st2()
    {
        return this.carList_st2;
    }

    public List<GameObject> getList_st3()
    {
        return this.carList_st3;
    }

    public List<GameObject> getList_st4()
    {
        return this.carList_st4;
    }
}

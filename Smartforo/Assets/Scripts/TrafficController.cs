using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public car_generator data;
    private List<GameObject> carList_st1;
    private List<GameObject> carList_st2;
    private List<GameObject> carList_st3;
    private List<GameObject> carList_st4;
    private bool isUpdatingList = false;
    private int traffic_st1_state = 1;
    private int traffic_st2_state = 1;
    public Traffic_Light_Con TrafficL;

    void Start()
    {
        
    }

    void Update()
    {
        if (isUpdatingList == false)
        {
            isUpdatingList = true;
            StartCoroutine(updateCarList());
        }

        if (TrafficL.getTrafficLightState() == 0)
        {
            trafficStop_st2();
            trafficResume_st1();
            print("estado 0");
        }
        else if (TrafficL.getTrafficLightState() == 1)
        {
            trafficStop_st1();
            trafficResume_st2();
            print("estado 1");
        }
        else
        {
            print(TrafficL.getTrafficLightState());
            trafficStop_st1();
            trafficStop_st2();
        }
    }

    private IEnumerator updateCarList()
    {
        yield return new WaitForSeconds(1f);
        carList_st1 = data.getList_st1();

        // for (int i=0; i < carList_st1.Count;i++)
        // {
        //     if (!carList_st1[i])
        //     {
        //         print(i);
        //     }
        // }

        carList_st2 = data.getList_st2();
        carList_st3 = data.getList_st3();
        carList_st4 = data.getList_st4();
        isUpdatingList = false;
    }


    void trafficStop_st1()
    {
        for (int i=0; i < carList_st1.Count; i++)
        {
            Vector3 carPos = carList_st1[i].GetComponent<car_settings>().getCarPosition();
            if (carPos.z <= -85f)
            {
                carList_st1[i].GetComponent<car_settings>().stop();
            }
        }

        for (int i=0; i < carList_st2.Count; i++)
        {
            Vector3 carPos = carList_st2[i].GetComponent<car_settings>().getCarPosition();
            if (carPos.z >= -31f)
            {
                carList_st2[i].GetComponent<car_settings>().stop();
            }
        }
        traffic_st1_state = 0;
    }

    void trafficResume_st1()
    {
        for (int i=0; i < carList_st1.Count; i++)
        {
            if (carList_st1[i] != null)
            {
                carList_st1[i].GetComponent<car_settings>().normalSpeed();
            }
        }
        for (int i=0; i < carList_st2.Count; i++)
        {
            if (carList_st2[i] != null)
            {
                carList_st2[i].GetComponent<car_settings>().normalSpeed();
            }
        }
        traffic_st1_state = 1;
    }

    void trafficStop_st2()
    {
        for (int i=0; i < carList_st3.Count; i++)
        {
            Vector3 carPos = carList_st3[i].GetComponent<car_settings>().getCarPosition();
            if (carPos.x > 62 && carList_st3 != null)
            {
                carList_st3[i].GetComponent<car_settings>().stop();
            }
        }
        for (int i=0; i < carList_st4.Count; i++)
        {
            Vector3 carPos = carList_st4[i].GetComponent<car_settings>().getCarPosition();
            if (carPos.x < 9 && carList_st3 != null)
            {
                carList_st4[i].GetComponent<car_settings>().stop();
            }
        }
        traffic_st2_state = 0;
    }

    void trafficResume_st2()
    {
        for (int i=0; i < carList_st3.Count; i++)
        {
            if (carList_st3[i] != null)
            {
                carList_st3[i].GetComponent<car_settings>().normalSpeed();
            }
        }
        for (int i=0; i < carList_st4.Count; i++)
        {
            if (carList_st4[i] != null)
            {
                carList_st4[i].GetComponent<car_settings>().normalSpeed();
            }
        }
        traffic_st2_state = 1;
    }
}


        // if (greenLight_st1 == 0 && traffic_st1_state == 1)
        // {
        //     trafficStop_st1();
        // }

        // if (greenLight_st1 == 1 && traffic_st1_state == 0)
        // {
        //     trafficResume_st1();
        // }

        // if (greenLight_st2 == 0 && traffic_st2_state == 1)
        // {
        //     trafficStop_st2();
        // }

        // if (greenLight_st2 == 1 && traffic_st2_state == 0)
        // {
        //     trafficResume_st2();
        // }
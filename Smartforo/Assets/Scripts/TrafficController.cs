using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public car_generator data;
    private List<GameObject> carList_st1_lane0;
    private List<GameObject> carList_st2_lane0;
    private List<GameObject> carList_st3_lane0;
    private List<GameObject> carList_st4_lane0;

    private List<GameObject> carList_st1_lane1;
    private List<GameObject> carList_st2_lane1;
    private List<GameObject> carList_st3_lane1;
    private List<GameObject> carList_st4_lane1;

    private bool isUpdatingList = false;
    private int traffic_st1_state = 1;
    private int traffic_st2_state = 1;
    public Traffic_Light_Con TrafficL;
    private bool isInCrashTest = false;

    private bool stopUpdating = false;

    void Start()
    {
        
    }

    void Update()
    {
        // if (isUpdatingList == false && stopUpdating == false)
        // {
        //     isUpdatingList = true;
        //     StartCoroutine(updateCarList());
        // }

        updateCarList();

        if (TrafficL.getTrafficLightState() == 0)
        {
            trafficStop_st2();
            trafficResume_st1();
        }
        else if (TrafficL.getTrafficLightState() == 1)
        {
            trafficStop_st1();
            trafficResume_st2();
        }
        else
        {
            trafficStop_st1();
            trafficStop_st2();
        }

        // if (isInCrashTest == false)
        // {
        //     isInCrashTest = true;
        //     StartCoroutine(crashController());
        // }

        crashController();
    }

    void crashController()
    {
        stopUpdating = true;

        if (carList_st1_lane0.Count >= 2)
        {
            for (int i=0; i < carList_st1_lane0.Count -1; i++)
            {
                if ((carList_st1_lane0[i].GetComponent<car_settings>().getCarPosition().z - carList_st1_lane0[i+1].GetComponent<car_settings>().getCarPosition().z) < 16)
                {
                    carList_st1_lane0[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st1_lane1.Count >= 2)
        {
            for (int i=0; i < carList_st1_lane1.Count -1; i++)
            {
                if ((carList_st1_lane1[i].GetComponent<car_settings>().getCarPosition().z - carList_st1_lane1[i+1].GetComponent<car_settings>().getCarPosition().z) < 16)
                {
                    carList_st1_lane1[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st2_lane0.Count >= 2)
        {
            for (int i=0; i < carList_st2_lane0.Count -1; i++)
            {
                if ((carList_st2_lane0[i+1].GetComponent<car_settings>().getCarPosition().z - carList_st2_lane0[i].GetComponent<car_settings>().getCarPosition().z) < 16)
                {
                    carList_st2_lane0[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st2_lane1.Count >= 2)
        {
            for (int i=0; i < carList_st1_lane1.Count -1; i++)
            {
                if ((carList_st2_lane1[i+1].GetComponent<car_settings>().getCarPosition().z - carList_st2_lane1[i].GetComponent<car_settings>().getCarPosition().z ) < 16)
                {
                    carList_st2_lane1[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st3_lane0.Count >= 2)
        {
            for (int i=0; i < carList_st3_lane0.Count -1; i++)
            {
                if ((carList_st3_lane0[i+1].GetComponent<car_settings>().getCarPosition().x - carList_st3_lane0[i].GetComponent<car_settings>().getCarPosition().x) < 16)
                {
                    carList_st3_lane0[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st3_lane1.Count >= 2)
        {
            for (int i=0; i < carList_st3_lane1.Count -1; i++)
            {
                if ((carList_st3_lane1[i+1].GetComponent<car_settings>().getCarPosition().x - carList_st3_lane1[i].GetComponent<car_settings>().getCarPosition().x) < 16)
                {
                    carList_st3_lane1[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st4_lane0.Count >= 2)
        {
            for (int i=0; i < carList_st4_lane0.Count -1; i++)
            {
                if ((carList_st4_lane0[i].GetComponent<car_settings>().getCarPosition().x - carList_st4_lane0[i+1].GetComponent<car_settings>().getCarPosition().x) < 16)
                {
                    carList_st4_lane0[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        if (carList_st4_lane1.Count >= 2)
        {
            for (int i=0; i < carList_st3_lane1.Count -1; i++)
            {
                if ((carList_st4_lane1[i].GetComponent<car_settings>().getCarPosition().x - carList_st4_lane1[i+1].GetComponent<car_settings>().getCarPosition().x) < 16)
                {
                    carList_st4_lane1[i+1].GetComponent<car_settings>().stop();
                }
            }
        }

        // yield return new WaitForSeconds(0.25f);
        stopUpdating = false;
        isInCrashTest = false;
    }

    void updateCarList()
    {
        carList_st1_lane0 = data.getList_st1_lane0();
        carList_st2_lane0 = data.getList_st2_lane0();
        carList_st3_lane0 = data.getList_st3_lane0();
        carList_st4_lane0 = data.getList_st4_lane0();
        carList_st1_lane1 = data.getList_st1_lane1();
        carList_st2_lane1 = data.getList_st2_lane1();
        carList_st3_lane1 = data.getList_st3_lane1();
        carList_st4_lane1 = data.getList_st4_lane1();
        // yield return new WaitForSeconds(0.25f);
        // yield return 1;
        isUpdatingList = false;
    }


    void trafficStop_st1()
    {
        if (carList_st1_lane0[0].GetComponent<car_settings>().getCarPosition().z > -95f &&
                carList_st1_lane0[0].GetComponent<car_settings>().getCarPosition().z < -85f)
        {
            carList_st1_lane0[0].GetComponent<car_settings>().stop();
        }
        if (carList_st1_lane1[0].GetComponent<car_settings>().getCarPosition().z >= -95f &&
                carList_st1_lane1[0].GetComponent<car_settings>().getCarPosition().z < -85f)
        {
            carList_st1_lane1[0].GetComponent<car_settings>().stop();
        }

        if (carList_st2_lane0[0].GetComponent<car_settings>().getCarPosition().z < -15f && 
                carList_st2_lane0[0].GetComponent<car_settings>().getCarPosition().z > -25f)
        {
            carList_st2_lane0[0].GetComponent<car_settings>().stop();
        }
        if (carList_st2_lane1[0].GetComponent<car_settings>().getCarPosition().z < -15f &&
                carList_st2_lane1[0].GetComponent<car_settings>().getCarPosition().z > -25f)
        {
            carList_st2_lane1[0].GetComponent<car_settings>().stop();
        }

        traffic_st1_state = 0;
    }

    void trafficResume_st1()
    {
        for (int i=0; i < carList_st1_lane0.Count; i++)
        {
            carList_st1_lane0[i].GetComponent<car_settings>().normalSpeed();
        }
        for (int i=0; i < carList_st1_lane1.Count; i++)
        {
            carList_st1_lane1[i].GetComponent<car_settings>().normalSpeed();
        }

        for (int i=0; i < carList_st2_lane0.Count; i++)
        {
            carList_st2_lane0[i].GetComponent<car_settings>().normalSpeed();
        }
        for (int i=0; i < carList_st2_lane1.Count; i++)
        {
            carList_st2_lane1[i].GetComponent<car_settings>().normalSpeed();
        }
        traffic_st1_state = 1;
    }

    void trafficStop_st2()
    {
        if (carList_st3_lane0[0].GetComponent<car_settings>().getCarPosition().x > 72f &&
                carList_st3_lane0[0].GetComponent<car_settings>().getCarPosition().x < 82f)
        {
            carList_st3_lane0[0].GetComponent<car_settings>().stop();
        }
        if (carList_st3_lane1[0].GetComponent<car_settings>().getCarPosition().x > 72f &&
                carList_st3_lane1[0].GetComponent<car_settings>().getCarPosition().x < 82f)
        {
            carList_st3_lane1[0].GetComponent<car_settings>().stop();
        }

        if (carList_st4_lane0[0].GetComponent<car_settings>().getCarPosition().x > -12f &&
                carList_st4_lane0[0].GetComponent<car_settings>().getCarPosition().x < -2f)
        {
            carList_st4_lane0[0].GetComponent<car_settings>().stop();
        }
        if (carList_st4_lane1[0].GetComponent<car_settings>().getCarPosition().x > -12f &&
                carList_st4_lane1[0].GetComponent<car_settings>().getCarPosition().x < -2f)
        {
            carList_st4_lane1[0].GetComponent<car_settings>().stop();
        }
    }

    void trafficResume_st2()
    {
        for (int i=0; i < carList_st3_lane0.Count; i++)
        {
            carList_st3_lane0[i].GetComponent<car_settings>().normalSpeed();
        }
        for (int i=0; i < carList_st3_lane1.Count; i++)
        {
            carList_st3_lane1[i].GetComponent<car_settings>().normalSpeed();
        }

        for (int i=0; i < carList_st4_lane0.Count; i++)
        {
            carList_st4_lane0[i].GetComponent<car_settings>().normalSpeed();
        }
        for (int i=0; i < carList_st4_lane1.Count; i++)
        {
            carList_st4_lane1[i].GetComponent<car_settings>().normalSpeed();
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
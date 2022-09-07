using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Light_Con : MonoBehaviour
{
    public MeshRenderer[] trafficLigths;
    private int currentState = 0;
    private bool isChangingState = false;

    void Start()
    {
        all_red();
    }

    void Update()
    {
        if (isChangingState == false)
        {
            isChangingState = true;
            StartCoroutine(changeState());
        }
    }

    private IEnumerator changeState()
    {
        yield return new WaitForSeconds(3f);

        if (currentState == 0)
        {
            green_st2();
        }
        else
        {
            green_st1();
        }
        isChangingState = false;
    }

    void green_st1()
    {
        all_red();
        trafficLigths[3].enabled = false;
        trafficLigths[1].enabled = false;
        trafficLigths[0].enabled = true;
        trafficLigths[2].enabled = true;
        currentState = 0;
    }

    void green_st2()
    {
        all_red();
        trafficLigths[4].enabled = true;
        trafficLigths[5].enabled = false;
        trafficLigths[6].enabled = true;
        trafficLigths[7].enabled = false;
        currentState = 1;
    }

    void all_red()
    {
        for (int i=0; i<8; i++)
        {
            if (i%2 == 0)
            {
                trafficLigths[i].enabled = false;
            }
            else
            {
                trafficLigths[i].enabled = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Light_Con : MonoBehaviour
{
    public MeshRenderer[] trafficLigths;
    private int currentState = 1;
    private bool isChangingState = false;

    private float[] semTime = new float[3600]; 
    private int counter = 0;

    void Start()
    {
        // setTm();
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

        if (currentState == 0)
        {
            green_st2();
        }
        else
        {
            green_st1();
        }
        // yield return new WaitForSeconds(semTime[counter]);
        yield return new WaitForSeconds(17.5f);

        int prevState = this.currentState;
        currentState = 2;
        yield return new WaitForSeconds(3.5f);
        currentState = prevState;
        isChangingState = false;
        counter++;
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

    public int getTrafficLightState()
    {
        return this.currentState;
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

    void setTm()
    {
        for (int i = 0; i < semTime.Length; i++)
        {
            float randomSeconds = Random.Range(17, 25);
            semTime[i] = randomSeconds;
        }
    }
}

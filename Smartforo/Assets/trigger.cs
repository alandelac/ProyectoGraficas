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

    public bool isSpaceAvailable()
    {
        return onTrigger;
    }

    public void prueba()
    {
        Debug.Log("Esoy en una prueba");
    }
}


        // Vector3[] streetList = new Vector3[] {new Vector3(40.0f, -0.66f, -208.0f), new Vector3(50.0f, -0.66f, -208.0f),
        //     new Vector3(30f, -0.66f, 91.0f), new Vector3(20.0f, -0.66f, 91.0f), new Vector3(186.0f, -0.66f, -53.0f),
        //     new Vector3(186.0f, -0.66f, -43.0f), new Vector3(-115f, -0.66f, -63.0f), new Vector3(-115f, -0.66f, -73.0f)};


        // if (st1_lane0_trigger.isSpaceAvailable() && isWaiting == false)
        // {
        //     float randomNumber = Random.Range(0, 2);
        //     if (randomNumber == 0f)
        //     {
        //         Instantiate(carro_st1, street1Lane0, Quaternion.Euler(0, 0, 0));
        //     }
        //     else
        //     {
        //         isWaiting = true;
        //         StartCoroutine(waitForCarToAppear());
        //     }
        // }

    //     for (int i=0; i < 8; i++)
    //     {
    //         if (triggerList[i].isSpaceAvailable() && isWaitingArr[i] == false)
    //         {
    //             float randomNumber = Random.Range(0, 2);
    //             if (randomNumber == 0f)
    //             {
    //                 Instantiate(carList[i/, streetList[i], Quaternion.Euler(0, 0, 0));
    //             }
    //             // else
    //             // {
    //             //     isWaitingArr[i] = true;
    //             //     StartCoroutine(waitForCarToAppear1(i));
    //             // }

    //         }
    //     }
    // }

    // // private IEnumerator waitForCarToAppear()
    // // {
    // //     float randomSeconds = Random.Range(1, 6);
    // //     Debug.Log("wait for car to appear");
    // //     yield return new WaitForSeconds(randomSeconds);
    // //     Instantiate(carro_st1, street1Lane0, Quaternion.Euler(0, 0, 0));
    // //     Debug.Log("wait is over");
    // //     isWaiting = false;
    // // }

    // private IEnumerator waitForCarToAppear1(int index)
    // {
    //     float randomSeconds = Random.Range(1, 6);
    //     Debug.Log("wait for car to appear");
    //     yield return new WaitForSeconds(randomSeconds);
    //     Instantiate(carList[index/2], streetList[index], Quaternion.Euler(0, 0, 0));
    //     Debug.Log("wait is over");
    //     isWaitingArr[index] = false;
    // }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st1_wayCon : MonoBehaviour
{
    private List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; 
    private int lastWaypointIndex;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    private Vector3 myVector;
    private Transform prueba;
    private Vector3 currentPos;
    private Vector3 initFinalPos;
    private GameObject newWaypointObject;
    private GameObject finalWaypoint;
    private int currentLane = 0;
    public int objectiveLane = 0;
    private int startingLane;
    private Vector3 initPos;
    private Vector3 finalPos;
    private Vector3 finalPosLane0;
    private Vector3 finalPosLane1;
    private Vector3 temp1;
    private Vector3 vPrueba;
    private bool doOnce = true;

	void Start () 
    {   
        newWaypointObject = new GameObject("aux_waypoint_st1");
        finalWaypoint = new GameObject("final_waypoint_st1");
        finalPosLane0  = new Vector3(40f, -0.66f, 92.6f);
        finalPosLane1 = new Vector3(50f, -0.66f, 92.6f);
        myVector = new Vector3(10.0f, -0.0f, 20.0f);

        initPos = this.transform.position;
        finalWaypoint.transform.position = finalPosLane0;
        waypoints.Add(finalWaypoint.transform);
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; 
	}

	void Update () {
        if (doOnce)
        {
            startLane1();
        }

        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 currentPos = this.transform.position;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); 

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

        if (objectiveLane == 1 && currentLane == 0)
        {
            print("changing to objective lane 1");
            changeToLane1();
        }
        if (objectiveLane == 0 && currentLane == 1)
        {
            print("changing to objective lane 0");
            changeToLane0();
        }

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); 
	}

    void startLane1()
    {
        doOnce = false;
        if (initPos.x < 45)
        {
            startingLane = 0;
        }
        if (initPos.x > 45)
        {
            startingLane = 1;
            waypoints[lastWaypointIndex].transform.position = finalPosLane1;
            objectiveLane = 1;
            currentLane = 1;
        }
    }

    public void stop()
    {
        this.movementSpeed = 0;
    }

    void changeToLane1()
    {
        myVector.x = 10;
        newWaypointObject.transform.position = this.transform.position + myVector; 
        waypoints.Insert(0, newWaypointObject.transform);
        finalPos = finalPosLane1;
        lastWaypointIndex++;
        waypoints[lastWaypointIndex].position = finalPos;
        currentLane = 1;
        targetWaypointIndex = 0;
        targetWaypoint = waypoints[0];
    }

    void changeToLane0()
    {
        myVector.x = -10;
        newWaypointObject.transform.position = this.transform.position + myVector;
        waypoints.Insert(0, newWaypointObject.transform);
        finalPos = finalPosLane0;
        lastWaypointIndex++;
        waypoints[lastWaypointIndex].position = finalPos;
        currentLane = 0;
        targetWaypointIndex = 0;
        targetWaypoint = waypoints[0];
    }
	
    Vector3 getLaneVector()
    {
        if (currentLane == 0)
        {
            temp1 = new Vector3(10.0f,0, 20.0f);
        }
        else
        {
            temp1 = new Vector3(-10.0f,0, 20.0f);
        }

        return this.currentPos + temp1;
    }
    
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if(currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        vPrueba = this.transform.position;
        vPrueba.y = -2;
        


        if(targetWaypointIndex > lastWaypointIndex)
        {
            Destroy(this);
            Destroy(this.gameObject);
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
}

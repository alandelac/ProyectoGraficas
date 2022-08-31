using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour {

    private List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastWaypointIndex;

    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public Street street;
    private Vector3 myVector;
    private Quaternion angle;
    public bool changeLane = false;
    private bool isChangingLane = false;
    private Transform prueba;

    private Transform currentPos;
    private Vector3 initFinalPos;


	// Use this for initialization
	void Start () 
    {   
        waypoints = street.get_waypoints();
        // print(waypoints[0].position.x);
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
        myVector = new Vector3(0.0f, 0.0f, 0.0f);
        angle = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        initFinalPos = new Vector3(waypoints[lastWaypointIndex].position.x, waypoints[lastWaypointIndex].position.y, waypoints[lastWaypointIndex].position.z);

	}
	
	// Update is called once per frame
	void Update () {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;

        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); 

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //Draws a ray forward in the direction the enemy is facing
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //Draws a ray in the direction of the current target waypoint

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

        if (changeLane == true)
        {
            changeWaypointsLane();
            isChangingLane = true;
        }
	}

    void changeWaypointsLane()
    {
        print("ready to change lanes");
        for (int i=0; i < waypoints.Count; i++)
        {
            float zPos = this.transform.position.z - waypoints[0].position.z + 20;
            Vector3 temp = new Vector3(10.0f,0, zPos);
            waypoints[i].transform.position += temp;
        }
        changeLane = false;
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
        if(targetWaypointIndex > lastWaypointIndex && isChangingLane == true)
        {
            print("return to final pos");
            Vector3 temp1 = new Vector3(10.0f,0, 0.0f);
            waypoints[lastWaypointIndex].transform.position =  initFinalPos +temp1;
            targetWaypointIndex = lastWaypointIndex;
        }


        if(targetWaypointIndex > lastWaypointIndex)
        {
            return;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
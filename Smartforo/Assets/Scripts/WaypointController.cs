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


	// Use this for initialization
	void Start () 
    {   
        waypoints = street.get_waypoints();
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
        myVector = new Vector3(0.0f, 0.0f, 0.0f);
        angle = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.transform.forward = new Vector3(1,0,0); //Whatever vector you want to use

	}
	
	// Update is called once per frame
	void Update () {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;

        print(directionToTarget);

        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget); 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); 

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //Draws a ray forward in the direction the enemy is facing
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //Draws a ray in the direction of the current target waypoint

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
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
        if(targetWaypointIndex > lastWaypointIndex)
        {
            return;
            targetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
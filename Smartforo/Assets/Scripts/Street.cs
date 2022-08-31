using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    public List<Transform> get_waypoints()
    {
        return this.waypoints;
    }
}

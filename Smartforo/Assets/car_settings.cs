using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_settings : MonoBehaviour
{
    private float speed = 12.5f;
    private float cruisingSpeed = 12.5f;

    void Start()
    {
        this.speed = 12.5f;
    }

    public float getCarSpeed()
    {
        return this.speed;
    }

    public void stop()
    {
        this.speed = 0;
    }

    public void changeCarSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    public Vector3 getCarPosition()
    {
        return this.transform.position;
    }

    public void normalSpeed()
    {
        this.speed = cruisingSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carroMove : MonoBehaviour
{

    public Rigidbody rb;
    public Transform car;
    public float actualSpeed = 10.0f;
    public GameObject[] checkpoints;
    int counter = 0;
    public float distance = 2.0f;
    public Vector3 direction;

    void Turn(float giro){
        this.transform.Rotate(0,giro,0);
    }

    void moveForward(){
        direction = Vector3.zero;
        direction = checkpoints[counter].transform.position - transform.position;

        if(direction.magnitude < distance){
            if(counter < checkpoints.Length-1){
                  counter++;
            }
            else{
                counter = 0;
            }
        }  
        direction = direction.normalized;
        Vector3 dir = direction;
 
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * actualSpeed, direction.y * actualSpeed);
    }


    WayPointContainer ruta;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    //CCNY M/W In-Class Script (My personal code)

    //GLOBAL VARIABLES
    public Rigidbody2D rbBall;  //Declare Rigidbody2D variable, set in Inspector via dragging and dropping.

    public float force = 200;  //Declare AND set force variable.

// ***Clarify with professor again the difference between public and private variables (jk, just look it up!)***
    private float xDir; //ONLY declaring x-axis direction as a float, not setting it equal to anything.

    private float yDir; //ONLY declaring y-axis direction as a float, no setting it equaL to anything.

    
    
    // Start is called before the first frame update
    void Start()
    {
        Launch();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Launch()
    {
        //Debug.Log("H3ll0 W3rld");

        Vector3 direction = new Vector3(0, 0, 0); //Declare and set anew Vector3 variable.
                                                  //Vector3(x,y,z) = representation of 3D vectors and points (can still be used in 2D projects!!)
        
        //Set direction.x (which way the ball moves horizontally)
        xDir = Random.Range(0, 2); //pick a random integer between 0 & 1.
        Debug.Log("xDir = " + xDir);

        if (xDir == 0) //if 0...
        {
            direction.x = -1; //set direction.x = -1, then go left.
            Debug.Log("Ball went Left.");
        } 
        else if (xDir == 1) //if 1...
        {
            direction.x = 1; //set direction.x = 1, then go right.
            Debug.Log("Ball went Right.");
        }


        //Set direction.y (which way the ball moves vertically)
        yDir = Random.Range(0, 2); //pick a random integer between 0 & 1.
        Debug.Log("yDir = " + yDir);

        if (yDir == 0) //if 0...
        {
            direction.y = -1; //set direction.y = -1,then go down.
            Debug.Log("Ball went Down.");
        }
        else if (yDir == 1) // if 1...
        {
            direction.y = 1; //set direction.y = 1, then go up.
            Debug.Log("Ball went Up.");
        }

        //add force to start movement
        rbBall.AddForce(direction * force); //launch the ball (apply force in a direction on the Rigidbody)

    }



}

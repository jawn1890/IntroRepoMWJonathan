using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    //M/W Class
    //GLOBAL VARIABLES
    //THINK ABOUT WHERE YOU WANT VARIABLES; WHETHER YOU WANT THEM GLOBAL OR  NOT.
    public Rigidbody2D rbBall;
    //You can make variables for specific functions.
    public float force = 200;
    //vs  public int - integers vs floats.
    private float xDir;
    private float yDir;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello Werld");
        
        Vector3 direction = new Vector3(0,0,0);

        xDir = Random.Range(0,2);
        //Debug.Log("xDir = " + xDir);
        if (xDir == 0)
        {
            direction.x = -1;
        } else if (xDir == 1)
        {
            direction.x = 1;
        }

        yDir = Random.Range(0,2);
        //Debug.Log("yDir = " + yDir);
        if (yDir == 0)
        {
            direction.y = -1;
        } else if (yDir == 1)
        {
            direction.y = 1;
        }

        //Add force to start movement.
        rbBall.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

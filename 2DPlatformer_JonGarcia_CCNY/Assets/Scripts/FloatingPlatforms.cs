using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    //GLOBAL VARIABLES
    //this code will be similar to the enemy movement stuff, except we're not checking for a collision or decreasing health

    //platform movement
    public Transform[] levitatePoints; // declaring a list called levitate points
    public float moveSpeed = 4; //setting a speed for the plaftorms
    public int platformDestination; // a variable that will tell the enemy which patrol point to move towards.



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMovement(); //here we are calling our platform moving script in update so that it's moving the platforms every frame throughout th entire game.
    }

    private void PlatformMovement() //the code for this is exactly the same as the Basic Enemy script, except this script will be attached to floating platforms.
    {
        if (platformDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, levitatePoints[0].position, moveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, levitatePoints[0].position) < 0.5)
            {
                platformDestination = 1;
            }
        }

        if (platformDestination == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, levitatePoints[1].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, levitatePoints[1].position) < 0.5)
            {
                platformDestination = 0;
            }
        }
    }

}

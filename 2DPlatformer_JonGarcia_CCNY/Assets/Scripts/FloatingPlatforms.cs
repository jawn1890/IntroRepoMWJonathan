using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    //GLOBAL VARIABLES
    //this code will be similar to the enemy movement stuff, except we're not checking for a collision or decreasing health

    //platform movement
    public Transform[] levitatePoints; // a list called levitate points
    //for the levitate points- could unique identifiers be used? eg. ascend/descend points? or would a numbered variable be more
    //appropriate for using a list?
    public float moveSpeed = 4; //setting a speed for the plaftorms
    public int platformDestination;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMovement();
    }

    private void PlatformMovement()
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

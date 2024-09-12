using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    //IN CLASS MW CCNY

    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //setting a reference to our projectile prefab game objects
    public Transform launchPoint; //setting coordinates for a position from which the projectile will launch.

    //Cool Down timer stuff
    public float shootTime = 0.5f; //tells the projectile how long to be shooting for.
    public float shootCount; //the shoot counter timer


    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime; //set the shoot counter timer equal to the shoot time when the scene starts.

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shootCount <= 0) //if the left mouse button is clicked AND shoot counter is less than or equal to 0...
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity); //instantiate had 3 parameters: (what) a prefab of the projectile, (where) at the launchpoint, and (rotation) keep its default rotation.
            shootCount = shootTime; //restart the cooldown timer to pause player's ability to shoot.
        }

        shootCount -= Time.deltaTime; //schootcount timer being decreased every frame by Time.deltaTime (i.e. continuously) when the shootcount timer reaches 0, you can shoot again.



    }
}

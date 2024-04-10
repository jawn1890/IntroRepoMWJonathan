using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    //IN CLASS MW CCNY

    //GLOBAL VARIABLES
    public GameObject projectilePrefab;
    public Transform launchPoint;

    //Cool Down timer stuff
    public float shootTime = 0.5f;
    public float shootCount;


    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shootCount <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCount = shootTime;
        }

        shootCount -= Time.deltaTime;



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsScript : MonoBehaviour
{
    //This script makes a thing move linearly towards a target
    //This movement style is simple, but a little robotic
    //Check out LerpScript.cs for a smoother movement style
    
    //What I'm moving towards
    public Vector3 Dest;
    //How fast I go
    public float Speed = 0.1f;

    void Update()
    {
        //Every frame, move towards my target
        transform.position = Vector3.MoveTowards(transform.position,Dest,Speed * Time.deltaTime);
    }
}

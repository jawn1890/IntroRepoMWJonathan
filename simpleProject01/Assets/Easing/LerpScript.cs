using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    //This is a smoothed movement script, that makes an object move a % of the distance
     //to a target every frame. This means it moves fast at first, then slows as it
     //approaches. Game devs love lerp--it's a simple movement that looks pretty good
     
     //For a real fancy movement system check out EaseScript.cs
    
    //What I'm moving towards
    public Vector3 Dest;
    //How fast I go
    public float Speed = 2;

    void Update()
    {
        //Every frame, move a % of the distance towards my target
        transform.position = Vector3.Lerp(transform.position,Dest,Speed*Time.deltaTime);
    }
}

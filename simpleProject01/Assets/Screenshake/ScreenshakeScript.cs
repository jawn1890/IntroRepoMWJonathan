using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenshakeScript : MonoBehaviour
{
    //How hard does it shake?
    public float Intensity = 1;
    
    //A countdown, while this is > 0 the screen shakes
    public float ShakeTimer = 0;
    
    //Where it was before it shook
    public Vector3 StartPos;

    private void Start()
    {
        //Record our start position
        StartPos = transform.position;
    }

    void Update()
    {
        //If we hit space, set the timer to be above 0
        if (Input.GetKeyDown(KeyCode.Space))
            ShakeTimer = 0.2f;
        //If we set it to be above 0. . .
        if (ShakeTimer > 0)
        {
            //Make it slowly count down
            ShakeTimer -= Time.deltaTime;
            //Calculate how much shake we want this frame
            Vector3 shake = new Vector3(Random.Range(-Intensity, Intensity),
                Random.Range(-Intensity, Intensity));
            //Set its position to be its start position plus the shake offset
            transform.position = StartPos + shake;
        }
        else //When we're done, go back to our start position
            transform.position = StartPos;
    }
}

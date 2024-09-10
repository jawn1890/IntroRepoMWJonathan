using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveScript : MonoBehaviour
{
    //How fast does it wiggle?
    public float GyrationSpeed = 3;
    //How hard does it wiggle?
    public float WiggleSize = 3;
    //How fast does it move left/right
    public float Movespeed = 5;
    //We use this to track where on the wiggle it is
    public float SinTimer = 0;
    
    void Update()
    {
        //The timer goes up
        //We multiply it by PI so one sub-wiggle takes 1 second
          //if GSpeed is set to 1
        SinTimer += Time.deltaTime * Mathf.PI * GyrationSpeed;
        //What's the object's vertical offset at this part of the wave?
        float wiggle = Mathf.Sin(SinTimer) * WiggleSize;
        //Move the object to the right
        float x = transform.position.x + (Movespeed * Time.deltaTime);
        //If we go off screen, wrap around
        if (transform.position.x > 10)
            x = -10;
        //Plug in our calculations to the object's position
        transform.position = new Vector3(x, wiggle);

    }
}

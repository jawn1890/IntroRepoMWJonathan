using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectProjectileScript : MonoBehaviour
{
    //This is a script for a perfectly-accurate homing projectile
    //It's not very fun to interact with, since you can't dodge it
    //A similar but better version can be found in HomingProjectileScript.cs

    //Movespeed
    public float Speed = 10;
    //What I'm homing in on
    public GameObject Target;

    void Start()
    {
        //If I haven't set a target, chase the player
        if(Target == null)
            Target = PlayerMovement.Player.gameObject;
    }

    void Update()
    {
        //Every frame, move towards my target
        transform.position = Vector3.MoveTowards(transform.position,
            Target.transform.position,Speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Self destruct if I hit anything
        Destroy(gameObject);
    }
}

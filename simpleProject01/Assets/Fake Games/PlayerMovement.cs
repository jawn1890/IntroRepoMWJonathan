using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Just a super simple movement script
    //We've done this before, so I won't comment it
    
    public static PlayerMovement Player;
    
    public Rigidbody2D RB;
    public float Speed = 5;

    private void Awake()
    {
        //The one thing I do that's a little fancy is
          //I record the player to a static variable
          //so they're easy to find
        Player = this;
    }

    void Update()
    {
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
            vel.x = Speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            vel.x = -Speed;
        if (Input.GetKey(KeyCode.UpArrow))
            vel.y = Speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            vel.y = -Speed;
        RB.velocity = vel;
    }
}

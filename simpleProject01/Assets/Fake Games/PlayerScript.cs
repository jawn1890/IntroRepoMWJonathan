using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    //I like to make variables for all my components even
        //if I'm not sure if I'll use them in code
    public SpriteRenderer SR;
    public Rigidbody2D RB;
    
    //My personal stats
    public float Speed = 5;
    public float StopSpeed = 5;
    public float JumpPower = 13;
    
    //Variables I use to track my state;
    public bool FacingLeft = false;
      //If this is over 0, I'm stunned and can't move
    public float Stunned = 0;

    //The list of solid object's I'm currently touching
    public List<GameObject> Grounds;
    
    //How I'd like to move left/right
    public float DesiredVel = 0;
    
    void Update()
    {
        //I'll use this variable to track the movement I want
        //By default, I move like I moved last frame
        Vector2 vel = RB.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
        { 
            //If I hit right, move right
            DesiredVel = Speed;
            //If I hit right, mark that I'm not facing left
            FacingLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        { 
            //If I hit left, move right
            DesiredVel = -Speed;
            //If I hit left, mark that I'm facing left
            FacingLeft = true;
        }
        else
        {  //If I hit neither, come to a stop
            DesiredVel = 0;
        }

        //Make my speed match my desired speed, but take a few frames
        vel.x = Mathf.Lerp(vel.x, DesiredVel,
            StopSpeed * Time.deltaTime);

        //If I hit Z and can jump, jump
        if (Input.GetKeyDown(KeyCode.Z) && CanJump())
        { 
            vel.y = JumpPower;
        }

        //Here I actually feed the Rigidbody the movement I want
        RB.velocity = vel;
        //Use my FacingLeft variable to make my sprite face the right way
        SR.flipX = FacingLeft;

        //If I fall into the void...
        if (transform.position.y < -20)
        {
            //Give me a game over
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    //I use this function to track if I can jump or not
    public bool CanJump()
    {
        //If I'm touching at least one solid object, I can jump
        return Grounds.Count > 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {  
        //If I collide with something solid, record it
        Grounds.Add(other.gameObject);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //If I stop touching something solid, unrecord it
        Grounds.Remove(other.gameObject);
    }
}

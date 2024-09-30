using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{ 
    //Variables for everything, even if you don't use them all
    public SpriteRenderer SR;
    public Rigidbody2D RB;
    public Collider2D Coll;
    public ParticleSystem PS;
    public AudioSource AS;
    
    //Player Stats
    public float Speed = 5;
    public float JumpPower = 50;
    public float Gravity = 3;
    
    //State-Tracking Variables
    public bool OnGround = false;
    public bool FacingLeft = false;
    public float Stunned = 0;
    
    //SoundFX
    public AudioClip JumpSFX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //At the start of the game, set the players gravity to our declared variable
        RB.gravityScale = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        //Code for movement and changing direction sprite is facing
        Vector2 vel = RB.velocity;
    
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            FacingLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            FacingLeft = true;
        }
        else
        {
            vel.x = 0;
        }
        
        //Code for jumping
        if (Input.GetKeyDown(KeyCode.Z) && CanJump())
        {
            vel.y = JumpPower;
            PS.Emit(5);
            AS.PlayOneShot(JumpSFX);
        }
        
        RB.velocity = vel;
        SR.flipX = FacingLeft;
        
        //Code for game over if falling off a platform
            //However, I need the actual asset files and project settings
        // if (transform.position.y > -20)
        // {
        //     SceneManager.LoadScene("You Lose");
        // }
        
        
    }
    //Public bool function for determining if player can jump
    public bool CanJump()
    {
        return OnGround;
    }
    
    
    
    
    
}
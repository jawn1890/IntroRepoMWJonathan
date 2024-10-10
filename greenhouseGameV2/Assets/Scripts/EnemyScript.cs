using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Variables
    public SpriteRenderer SR;
    public Rigidbody2D RB;
    public Collider2D Coll; //main collider
    public Collider2D Nose; //'Did I bump into a wall' check
    
    //Personal Stats
    public float Speed = 2;
    public float Gravity = 3;
    
    //Variables to track my state
    public bool OnGround = false;
    public bool FacingLeft = false;

    public 
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Let the Game Manager know I exist when the game starts
        GameManager.Me.AllEnemies.Add(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Variable to track enemy movement
        //By default, move like the last frame
        Vector2 vel = RB.velocity;
        
        //If I'm facing right, move right
      /*  if (!FacingLeft)
        {
            vel.x = Speed;
        }
        //If I'm facing left, move left
        else if (FacingLeft)
        {
            vel.x = -Speed;
        }*/
        
        //Actually giving the Rigidbody the movement I want
        RB.velocity = vel;
        
        //Self destruct if enemy falls off the screen
        if (transform.position.y < 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If my "nose" touches a solid object
        if (other.otherCollider == Nose)
        {
            TurnAround();
        }
        
    }

    public void TurnAround()
    {
        //Set FacingLeft and !FacingLeft equal to each other
        FacingLeft = !FacingLeft;
        //Use my FacingLeft variable to turn my whole body around
        if (FacingLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }

    private void OnDestroy()
    {
        //When I die, remove me from the enemies list in the Game Manger
        GameManager.Me.AllEnemies.Remove(this);
    }
    
}

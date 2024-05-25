using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //IN CLASS CCNY MW

    //GLOBAL VARIABLES
    public Rigidbody2D projectileRb; //declare and set the rigid body for the projectile in the inspector.
    public float speed = 500f; //set how fast the projectile can go. this can be changed in the inspector.

    //Projectile Countdown Timer Stuff
    public float projectileLife = 2; //the length of time the projectile will exist, which will be 2 seconds.
    public float projectileCount; //counts down the time until the projectile destroys itself. currently set to 0.

    //flip launch projectile direction
    public PlayerController playerControllerScript; //a reference to the PlayerController script.
    public bool facingLeft;  //a bool to determine whether we're facing left or right. this will help determine which side/direction the projectile is coming from and going, respectively.


    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife; //setting the projectile countdown timer to projectile life, 2 seconds.

        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); //finding the game object tagged player from the PlayerController script.

        facingLeft = playerControllerScript.facingLeft; //setting our facing left bool equal to the facing left bool from the player controller script. essentially copying the players facing direction to this script.
        if (!facingLeft) //if the player is facing right...
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //rotate the projectile on the y axis.
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime; //reduces the projectile count with each second.
        if (projectileCount <= 0) //if projectile timer runs out...
        {
            Destroy(gameObject); //destroy the gameobject that this script is attached to.
        }
    }

    private void FixedUpdate()
    //FixedUpdate() is called every fixed framerate frame. it runs exactly 50 times per second every time.
    //when applying force, torque, or physics related things, its better to use FixedUpdate() because it runs in syc with the physics engine, rather than just with the framerate.
    //this is also helpful sometimes because framrates vary vastly across hardware.
    //movement with rigidbody stuff should be used with FixedUpdate()
    //moving by transforming ca be done with regular Update().
    {
        if (!facingLeft) //if facingLeft is false; if we're facing right.
        {
        projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0); //shoot to the right based on the vector3 parameters.
        }
        else //if we're facig left...
        {
        projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0); //shoot to the left.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //collision detection for instances of this gameobject (because it doesn't always exist by default in the scene)
    {
        // if (collision.gameObject.tag == "Lava")
        // {
        //     //Debug.Log("projectile hit lava!");
        //     Destroy(collision.gameObject); //this line of code is to destroy the object that THIS object HITS.
        // }

        if (collision.gameObject.tag == "Enemy") //if this object collides with an object tagged enemy...
        {
            //Debug.Log("projectile hit enemy!"); //debug log printed to the console to tell that we hit an enemy.
            Destroy(collision.gameObject); //destroy the gameobject that this object collides with.
        }

        Destroy(gameObject); //this line of code is outside the specific collision checks, so THIS OBJECT gets destroyed when hitting ANYTHING.
    }
}

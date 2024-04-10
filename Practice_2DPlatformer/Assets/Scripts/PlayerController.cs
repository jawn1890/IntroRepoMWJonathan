using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Practice for 2D Platformer!!!

    //GLOBAL VARIABLES
    public Rigidbody2D playerBody; //1st variable. we are creating a public RigidBody2D and naming it playerBody.
    public float playerSpeed = 0.05f; //2nd variable. this float is called playerSpeed and we're setting it to a very small float 0.05f.
    public float jumpForce = 300; //3rd variable. declaring a float called jumpForce and setting it to 300. a higher number is necessary for a significant force to be applied.
    public bool isJumping = false; //4th variable. this bool is to check it we are jumping. it is set to false at the start of the game because we do not start the game jumping!


    //Variables for Player Health will go  here...



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    //Creating a new private void for moving the player. We will do the same for jumping!
    //This should be run in Update so that it is called every frame, but we will simply call this method in Update to keep our code cleaner. 
    private void MovePlayer()
    {
        Vector3 newPos = transform.position; //Declaring a new Vector3 at the transform.position of this object (the player).
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A Pressed!");
            newPos.x -= playerSpeed; //When A is pressed, newPos.x will subtract playerSpeed from itself to decrease its x value, moving it to the left.
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D Pressed!");
            newPos.x += playerSpeed; //When D is pressed, newPos.x will add playerSpeed to itself to increase its x value, moving it to the right.
        }

        transform.position = newPos; //Then, we are setting the transform.position equal to the newly updated newPos (based on the key pressed).

    }
    
    private void Jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space Pressed!");
            playerBody.AddForce(new Vector3 (playerBody.velocity.x, jumpForce, 0));
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag =="Spike")
        {
            Debug.Log("OUCH!!");
        }
    }
}

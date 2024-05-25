using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //The First script we're making today April 1st, 2024
    //Trying to annotate as we go along.
    //IN CLASS MW CCNY

    //GLOBAL VARIABLES
    public Rigidbody2D playerBody; //1st variable, RigidBody2D and naming it playerBody.
    public float playerSpeed = 0.5f; //2nd variable , float called playerSpeed and set to a very small float.
    public float jumpForce = 600; //3rd variable, usually a bigger number for a force to occur, as opposed to changing a tiny number to move around./
    public bool isJumping = false; //4th variable, a bool, to see if we are jumping. setting it to false because we dont start the game jumping.

    //player health
    public int maxHealth = 20; //a variable for the player's max health- we are immediately setting it to 20.
    public int currentHealth; //a variable for the players current health.
    public HealthBar healthBarScript; //a reference to the HealthBar script.

    //sprite direction flipping variables
    public bool flippedLeft; //keeps track of which way our sprite IS CURRENTLY facing.
    public bool facingLeft; //keeps track of which way our sprite SHOULD BE facing.




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //when the game starts, set the player's current health to max health so you're not starting with anything less than full health.
        healthBarScript.SetMaxHealth(maxHealth); //talking to the Health Bar script to reflect a full health bar visually on the canvas.
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //After creating our private void (MovePlayer), it needs to be called- here it will be called every frame in Update.
        Jump(); //same for the jump function. these live in update because we need to be able to move and jump for every frame of the entire game.
    }


    private void MovePlayer() 
    //This void can be private because we don't need to call/reference it from anywhere else.
    //We need this to be in Update to be called every frame, but we will create a new void to keep it more organized.
        {
            Vector3 newPos = transform.position; //New vector3 at the transform.psotion that this object is attached to.
            if (Input.GetKey(KeyCode.A)) //Checking for A and D button presses using Debug Logs.
            {
                //Debug.Log("A pressed");
               newPos.x -= playerSpeed; //When A is pressed, newPos.x will subtract playerSpeed, decreasing the value of x, causing it to move to the left.
               facingLeft = true; //facing left set to true
               Flip(facingLeft); //calling the flip function with a true boolean to actually flip us left
            
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("D pressed");
                newPos.x += playerSpeed; //When D is pressed, newPos.x will add playerSpeed, increasing the value of x, causing it to move to the right
                facingLeft = false; //facing left is set to false
                Flip(facingLeft); //calling the flip functio with a false boolean to turn us right.
            }

            transform.position = newPos; //We are then setting the transform.position equal to the newly updated newPos (based on the key pressed).
            
        }
        

    private void Jump() //New private void for jumping!
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) //For jump, we're using GetKeyDown instead of GetKey, because we only want to jump for the frame that we press SPACE.
        //Also, this basically says if you're not jumping and space is pressed, you're allowed to jump! This helps stop double/triple jumping.
        {
            //Debug.Log("SPACE pressed"); //debug log printed to the console to tell us that the spacebar is pressed.
            playerBody.AddForce(new Vector3 (playerBody.velocity.x, jumpForce, 0)); //To add force, we need a new vector3 to tell it which way to go.
            //We can say playerBody.AddForce (add a force to the player), and the 3 parameters are 
            isJumping = true; //set to true because we are actually jumping now.
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //creating a new private void to detect collisions. not the only way to do this though.
    {
        if (collision.gameObject.tag == "Surface") //remember, if checks always require double operands, eg. ==, &&, ||, so if the player collides with a game object tagged surface
        {
            isJumping = false; //isJumping is set to false because we are not jumping currently.
        }

        //(i ultimately didn't end up using this in my game)
        // if (collision.gameObject.tag == "Lava") //if the player collides with an object tagged lava
        // {
        //     lavaRockAudio.Play(); //play lava audio
        //     TakeDamage(2); //call TakeDamage() to reduce player's health by 2 points. the two here is fed to the function below so that the function knows how much damage to cause.
        // }

        if (collision.gameObject.tag == "Coin") //if the player collides with an object tagged coin...
        {
            //Debug.Log("We got a coin!"); //debug log printed to the console to tell us that we have collected a coin
            Destroy(collision.gameObject); //destroy the game object being collided with, in this case, a coin, and make it look like we collected it.
        }

    }

    public void TakeDamage(int damage) //the script to deal damage to the player. requires an integer to specify damage being inflicted
    {
        currentHealth -= damage; //whatever our current health is minue the amount of damage being inflicted.
        healthBarScript.SetHealth(currentHealth); //talking to the healthbar script to decrease some of the health bar on the canvas.
    }

    void Flip(bool facingLeft) //"void" without a specific designation is by default private.
    {
        //Debug.Log("Flip() called. facingLeft = " + facingLeft); //debug log printed to the console to show the function being called.
        if (facingLeft && !flippedLeft) //if facing left is true but we're flipped right...
        {
            transform.Rotate(0, -180, 0); //flip the sprite on its y axis
            flippedLeft = true; //set flipped left to true because we flipped left!
        }

        if (!facingLeft && flippedLeft) //if we're facing right but flipped left is true...
        {
            transform.Rotate(0, 180, 0); //flkip the sprite again on its y axis.
            flippedLeft = false; //set flipped left to false. this will create a loop in which you are always able to flip left and right.
        }


    }


}

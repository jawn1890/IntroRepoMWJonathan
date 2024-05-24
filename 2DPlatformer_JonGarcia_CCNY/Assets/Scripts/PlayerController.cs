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
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBarScript;

    //sprite direction flipping variables
    public bool flippedLeft; //keeps track of which way our sprite IS CURRENTLY facing.
    public bool facingLeft; //keeps track of which way our sprite SHOULD BE facing.


    //sound effect stuff
    public AudioSource lavaRockAudio;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //After creating our private void (MovePlayer), it needs to be called- here it will be called every frame in Update.
        Jump();
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
               facingLeft = true;
               Flip(facingLeft);
            
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("D pressed");
                newPos.x += playerSpeed; //When D is pressed, newPos.x will add playerSpeed, increasing the value of x, causing it to move to the right
                facingLeft = false;
                Flip(facingLeft);
            }

            transform.position = newPos; //We are then setting the transform.position equal to the newly updated newPos (based on the key pressed).
            
        }
        

    private void Jump() //New private void for jumping!
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) //For jump, we're using GetKeyDown instead of GetKey, because we only want to jump for the frame that we press SPACE.
        //Also, this basically says if you're not jumping and space is pressed, you're allowed to jump! This helps stop double/triple jumping.
        {
            //Debug.Log("SPACE pressed");
            playerBody.AddForce(new Vector3 (playerBody.velocity.x, jumpForce, 0)); //To add force, we need a new vector3 to tell it which way to go.
            //We can say playerBody.AddForce (add a force to the player), and the 3 parameters are 
            isJumping = true; //because we are actually jumping now.
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //creating a new private void to detect collisions. not the only way to do this though.
    {
        if (collision.gameObject.tag == "Surface") //remember, if checks always require double operands, eg. ==, &&, ||
        {
            isJumping = false;
        }

        
        if (collision.gameObject.tag == "Lava")
        {
            lavaRockAudio.Play(); //play lava audio
            TakeDamage(2);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("We got a coin!");
            Destroy(collision.gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarScript.SetHealth(currentHealth);
    }

    void Flip(bool facingLeft) //"void" without a specific designation is by default private.
    {
        //Debug.Log("Flip() called. facingLeft = " + facingLeft);
        if (facingLeft && !flippedLeft)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true;
        }

        if (!facingLeft && flippedLeft)
        {
            transform.Rotate(0, 180, 0);
            flippedLeft = false;
        }


    }


}

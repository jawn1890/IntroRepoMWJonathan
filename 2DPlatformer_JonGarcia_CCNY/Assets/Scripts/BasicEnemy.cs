using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //IN CLASS CCNY MW
    //GLOBAL VARIABLES

    public int damage;// an integer to store the amount of damage inflicted by an enemy on player.
    public PlayerController playerControllerScript; //a reference to the player controller script for acquiring some of its information.

    //Enemy Movement
    public Transform[] patrolPoints; //a list called patrolPoints
    public float moveSpeed = 3; //set a speed for the enemies
    public int patrolDestination; //a variable to hold the current patrol destination of the enemies.

    //Changing the enemy sprite direction
    public bool flippedLeft; //a bool to check if the enemy is flipped left yet.
    public bool facingLeft; // a bool to check if the enemy is facing left yet.
    public bool flippedUp; // a bool to check if the enemy is flipped up yet (basically changed around the vertical patrol to work horizontally)
    public bool facingUp; // a bool to check if the enemy is facing up yet.




    // Start is called before the first frame update
    void Start()
    {
        damage = 5; // set the amount of damage enemies will inflict at the start of the game.
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement(); //we are calling the EnemyMovement function every frame to make the enemies move.
    }

    private void OnCollisionEnter2D(Collision2D collision) //this is the collision check void
    {
        if (collision.gameObject.tag == "Player") //if this object collides with a game object tagged "player" then some code will run.
        {
            //Debug.Log("hit player"); debug log to check that the enemy has in fact hit the player.
            playerControllerScript.TakeDamage(damage); // talking to the player controller script to tell it to reduce the player's health by damage (5).
        }
    }


    private void EnemyMovement() //Instead of duplicating each ennemy manually, you can make an enemy a prefab and add the code/inspector info to it to change it for the appropriate patrol points. Could I also prefab the ground, patrolpoints, etc. or even prefab the enemies AND patrol points together!
    { 
        //This is where the movement for enemies happens.
        if (patrolDestination == 0) //if the patrol destination is 0, code will run.
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime); // this line gives the enemy a direction and moves it towards the specified patrol point constantly (in this case, 0)
            facingLeft = true; //this enemy is facing left.
            Flip(facingLeft); // this actually runs the code to make sure the enemy is flipped left.
            
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5) //if the enemy comes wiithin a distance of 0.5 from the patrol point...
            {
                patrolDestination = 1; // we specicfy the patrol destination in the opposite direction.
            }
        }

        if (patrolDestination == 1) //if the patrol destination is 1, code will run.
        {
            //Debug.Log("change direction"); //debug log to make sure the enemy will change direction.
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime); // this line gives the enemy a direction and moves it towards the specified patrol point constantly (in this case, 1)
            facingLeft = false; //this enemy is facing right.
            Flip(facingLeft); // this actually runs the code to make sure the enemy is flipped right.

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5) // if the enemy comes within a distance of 0.5 from the patrol point...
            {
                patrolDestination = 0; //we specify the patrol point in the opposite direction.
            }
        }

        // These next two if statements do the same exact thing as the previous patrol poinits code, except this allows the sprite to simply be flipped in the appropriate up and down directions.
        //The only new code is the Reverse() function I made to hold the different values for flipping the sprites on their x axes instead of their y axes.
        if (patrolDestination == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
            facingUp = true;
            Reverse(facingLeft);

            if (Vector3.Distance(transform.position, patrolPoints[2].position) < 0.5)
            {
                patrolDestination = 3;
            }
        }

        if (patrolDestination == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[3].position, moveSpeed * Time.deltaTime);
            facingUp = false;
            Reverse(facingUp);

            if (Vector3.Distance(transform.position, patrolPoints[3].position) < 0.5)
            {
                patrolDestination = 4;
            }
        }
    }

    void Flip(bool facingLeft)
    {
        if (facingLeft && !flippedLeft)
        {
            //Debug.Log("enemy turned left");
            transform.Rotate(-180, 0, 0);
            flippedLeft = true;
        }

        if (!facingLeft && flippedLeft)
        {
            //Debug.Log("enemy turned right");
            transform.Rotate(180, 0, 0);
            flippedLeft = false;
        }

    }

    void Reverse(bool facingUp)
    {
        if (facingUp && !flippedUp)
        {
            //Debug.Log("enemy moving up");
            transform.Rotate(0, 180, 0);
            flippedUp = true;
        }

        if (!facingUp && flippedUp)
        {
            //Debug.Log("enemy moving down");
            transform.Rotate(0, -180, 0);
            flippedUp = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //IN CLASS CCNY MW
    //GLOBAL VARIABLES

    public int damage;
    public PlayerController playerControllerScript;

    //Enemy Movement
    public Transform[] patrolPoints; //a list called patrolPoints
    public float moveSpeed = 3; //set a speed for the enemies
    public int patrolDestination; 

    //Changing the enemy sprite direction
    public bool flippedLeft;
    public bool facingLeft;
    public bool flippedUp;
    public bool facingUp;




    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
            playerControllerScript.TakeDamage(damage);
        }
    }


    private void EnemyMovement() //Instead of duplicating each ennemy manually, you can make an enemy a prefab and add the code/inspector info to it to change it for the appropriate patrol points. Could I also prefab the ground, patrolpoints, etc. or even prefab the enemies AND patrol points together!
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            facingLeft = true;
            Flip(facingLeft);
            
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5)
            {
                patrolDestination = 1;
            }
        }

        if (patrolDestination == 1)
        {
            //Debug.Log("change direction");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            facingLeft = false;
            Flip(facingLeft);

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)
            {
                patrolDestination = 0;
            }
        }

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
            Debug.Log("enemy turned left");
            transform.Rotate(-180, 0, 0);
            flippedLeft = true;
        }

        if (!facingLeft && flippedLeft)
        {
            Debug.Log("enemy turned right");
            transform.Rotate(180, 0, 0);
            flippedLeft = false;
        }

    }

    void Reverse(bool facingUp)
    {
        if (facingUp && !flippedUp)
        {
            Debug.Log("enemy moving up");
            transform.Rotate(0, 180, 0);
            flippedUp = true;
        }

        if (!facingUp && flippedUp)
        {
            Debug.Log("enemy moving down");
            transform.Rotate(0, -180, 0);
            flippedUp = false;
        }
    }

}

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
            
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.5)
            {
                patrolDestination = 1;
            }
        
        }

        if (patrolDestination == 1)
        {
            //Debug.Log("change direction");
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.5)
            {
                patrolDestination = 0;
            }
        }
    }

}

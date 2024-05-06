using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //IN CLASS CCNY MW

    //GLOBAL VARIABLES
    public Rigidbody2D projectileRb;
    public float speed = 5;

    //Projectile Countdown Timer Stuff
    public float projectileLife = 2;
    public float projectileCount;

    //flip launch projectile direction
    public PlayerController playerControllerScript;
    public bool facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;

        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        facingLeft = playerControllerScript.facingLeft;
        if (!facingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!facingLeft) //if facingLeft is true; if we're facing left.
        {
        projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0);
        }
        else
        {
        projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0);
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Debug.Log("projectile hit lava!");
            Destroy(collision.gameObject); //this line of code is to destory the object that THIS object HITS.
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("projectile hit enemy!");
            Destroy(collision.gameObject);
        }

        Destroy(gameObject); //this line of code is outside the collision check for lava rocks so that this OBJECT gets destroyed when hitting ANYTHING.
    }
}

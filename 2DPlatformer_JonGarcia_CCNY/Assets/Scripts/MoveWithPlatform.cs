using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    //GLOBAL VARIABLES
    //this script will help the player stay on the moving platforms as opposed to the player staying still and the platform passing underneath them.
    public bool onPlatform; //a bool to determine whether we're on the platform or not.



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //collision checks
    {
        if (collision.gameObject.tag == "Player") //if the game object this script is attached to collides with the player (i.e. if the player jumps on the platform)
        {
            onPlatform = true; //the onPlatform bool is set to true because we are o the platform.
            collision.collider.transform.SetParent(transform); //we are setting any moving platform as the parent of the player temporarily so that the player's coordinates are the same as the platform's.
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //checking for the end of the collision (i.e. if the player jumps off the platform, thus ending the collision)
    {
        if (collision.gameObject.tag == "Player") //if the game object is the player
        {
            collision.collider.transform.SetParent(null); //remove the player as a child of the platform.
        }
    }
}

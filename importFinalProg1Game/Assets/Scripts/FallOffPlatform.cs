using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOffPlatform : MonoBehaviour
{
    //GLOBAL VARIABLES
    public int sceneID; // declarng a public integer to be edited in the inspector. this number corresponds to the scene being called- we have 5 scenes labeled from 0-4. lists in unity and c# start at 0 instead of 1.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//this script only needs one function to be called and it's for the use of a trigger. when the player falls off platforms and onto this invisible trigger collider, the game is over and the player is prompted to start again.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // if the player collides with the game object that this script is on...
        {
            //Debug.Log("Fell Off The Platform!"); a debug log to check if the code is working/the collision is actually being detected.
            SceneManager.LoadScene(sceneID); // this line tells the scene manager to load the scene specified in the inspector. the scene numbers are manually set in the inspector and we can tell the game which scene we wannt depending on either a button press or a trigger (like falling off a platform onto spikes.)
        }


    }
}

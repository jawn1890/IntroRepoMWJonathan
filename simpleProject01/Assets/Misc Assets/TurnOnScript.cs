using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOnScript : MonoBehaviour
{
    //A list of scripts to activate
    public List<MonoBehaviour> Scripts;
    
    void Update()
    {
        //If I hit space, turn all the scripts on
        //In this case, this means make all the faces start to move
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (MonoBehaviour s in Scripts)
            {
                s.enabled = true;
            }
        }
        //Reset the game if I hit R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

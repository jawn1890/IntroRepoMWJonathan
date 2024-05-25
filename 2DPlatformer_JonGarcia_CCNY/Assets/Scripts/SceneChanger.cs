using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //including the scene management library when using this script.


public class SceneChanger : MonoBehaviour
{
    //GLOBAL VARIABLES

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToScene(int sceneID) //this very simple script is used to control the different scenes whenever a UI button is pressed. this code works to change to any scene number specified in the inspector.
    //the only scee that does not utilize this script is the main gameplay scene. that scene uses triggers to either cause a game over if you fall off a platform, or causes the winning scene upon completign the level.
    //this function requires an integer for a scene which is set in the inspector.
    {
        SceneManager.LoadScene(sceneID); //this line of code loads the specified scene upon execution.
    }

}

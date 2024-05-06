using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //GLOBAL VARIABLES
    public bool gameOver;
    public int sceneNumber;
        //0 = StartScene
        //1 = MainScene
        //2 = EndScene
public PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sceneNumber == 0)
        {
            StartSceneControls();
        }
        else if (sceneNumber == 1)
        {
            MainSceneControls();
        }
        else if (sceneNumber == 2)
        {
            EndSceneControls();
        }
    }

    public void StartSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //First we're gonna debug; just checking to see if the spacebar press is registered.
            SceneManager.LoadScene("MainScene");
            //Debug.Log("Spacebar Pressed");

        }
    }

    public void MainSceneControls()
    {
        gameOver = playerControllerScript.gameOver;

        if (gameOver)
        {
            //Debugging to check if this script is being called when falling off a platform.
            //Debug.Log("Game Over!");
            SceneManager.LoadScene("EndScene");
            
        }
        
    }

    public void EndSceneControls()
    {
        //Debug.Log("End Scene");

        if (Input.GetKeyDown(KeyCode.Return))
        {

            //Checking that the return key is pressed.
            //Debug.Log("Enter Key Pressed");
            gameOver = false;
            SceneManager.LoadScene("StartScene");
        }
    }
}

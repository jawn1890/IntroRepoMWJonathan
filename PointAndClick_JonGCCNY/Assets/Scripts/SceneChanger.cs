using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Use Scene Management Library

public class SceneChanger : MonoBehaviour
{

// CCNY MW IN CLASS

//GLOBAL VARIABLES
public int sceneNumber;
    //0 = StartScene
    //1 = MainScene
    //2 = EndScene


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneNumber == 0) //we're in the start scene
        {
            StartSceneControls();
        } else if (sceneNumber == 1) //we're in the main scene
        {
            MainSceneControls();
        } else if (sceneNumber == 2) //we're in the end scene
        {
            EndSceneControls();
        }
    }

    public void StartSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
            //Debug.Log("Return Pressed");
        }
    }

    public void MainSceneControls()
    {
        //code is the same as StartSceneControls, just with different keys
        //Debug.Log("main scene controls");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void EndSceneControls()
    {
        //code is the same as MainSceneControls, just with different keys
        //Debug.Log("end scene controls");
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartScene");
        }
    }


}

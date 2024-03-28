using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Use the Scene Management Library

//MW In Class CCNY

//MIDTERM PROJECT 3/28/2024 Jonathan Garcia



public class SceneChanger : MonoBehaviour
{
    //GLOBAL VARIABLES
    public int sceneNumber;
        //0 = StartScene
        //1 = SnakePlayScene
        //2 = GameOverScene



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Using if statements to continuously check the sceneNumber every frame.
        if (sceneNumber == 0) //We're in StartScene
        {
            StartSceneControls(); //Call the method to allow the StartScene to be changed with a key press.
        }
        else if (sceneNumber == 1) //We're in SnakePlayScene
        {
            SnakePlaySceneControls(); //Call the method to allow the SnakePlayScene to be changed with a key press.
        }
        else if (sceneNumber == 2) //We're in GameOverScene
        {
            GameOverSceneControls(); //Call the method to allow the GameOver scene to be changed with a key press.
        }
    }

    public void StartSceneControls()
    {
        //When this method is called, if the Return key is pressed, the scene manager will switch the scene from StartScene to SnakePlayScene and display a debug log.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SnakePlayScene");
            Debug.Log("Will Load Snake Play Scene");
            
        }
    }

    public void SnakePlaySceneControls()
    {
        //When this method is called, if the G key is pressed, the scene manager will switch the scene from SnakePlayScene to GameOverScene and display a debug log.
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("Will Load Game Over Scene");
        }
    }

    public void GameOverSceneControls()
    {
        //When this method is called, if the Space Bar is pressed, the scene manager will switch the scene from GameOverScene to StartScene and display a debug log. This effectively starts the game over.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScene");
            Debug.Log("Will Load Start Scene");
        }
    }



}

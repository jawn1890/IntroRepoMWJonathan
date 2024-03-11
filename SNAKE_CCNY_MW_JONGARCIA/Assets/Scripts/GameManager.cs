using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    //GLOBAL VARIABLES
    public TextMeshProUGUI foodScoreText;
    public int foodScore = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodScoreText.text = "Score: " + foodScore;
    }

    public void FoodEaten()
    {
        foodScore++;
    }


//Tried to create a new function to make the score change to game over.
//Perhaps I should create a reset and paused state of the game that it reverts to before just starting over.
//Perhaps that way I can have the GAME OVER screen be the final state and after pressing a button, start everything over.
    // public void ObstacleHit()
    // {
    //     foodScoreText.text = "GAME OVER";
    // }
}

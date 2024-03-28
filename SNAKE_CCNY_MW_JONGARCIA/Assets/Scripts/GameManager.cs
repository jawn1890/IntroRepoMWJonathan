using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Include the TextMeshPro library for using TMPro elements.

//MW In Class CCNY

//MIDTERM PROJECT 3/28/2024 Jonathan Garcia



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    //GLOBAL VARIABLES
    public TextMeshProUGUI foodScoreText; //References the Food Score element attached to the GameManager object in the Inspector.
    public int foodScore = 0; //Declaring an integer for the score and setting it equal to 0 in one line of code.

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foodScoreText.text = "Score: " + foodScore; //Every frame, this prints the score of the player on the canvas via the text field in the Inspector.
    }

    //I created a public void called FoodEaten to be used in other scripts in the game.
    public void FoodEaten()
    {
        foodScore++; //When this method is called, the value of foodScore is increased by 1 and plugged into the line of code in Update to show the updated score in the game.
    }

    //This public void is for decreasing the score when a piece of poison is eaten.
    public void PoisonEaten()
    {
        foodScore--; // When this method is called, the value of foodScore is decreased by 1 and plugged into the line of code in Update to show the updated score in the game.
    }

}

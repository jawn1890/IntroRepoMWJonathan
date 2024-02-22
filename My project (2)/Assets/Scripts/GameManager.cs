using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    //MW CCNY Class

    //GLOBAL VARIABLES
    //Game objects for UI elements

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    
    //SCORES!
    private int player1Score = 0;
    private int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreText.text = "P1: " + player1Score;
        player2ScoreText.text = "P2: " + player2Score;
    }

    public void Player1Scored()
    {
        player1Score++;
    }

    public void Player2Scored()
    {
        player2Score++;
    }



}

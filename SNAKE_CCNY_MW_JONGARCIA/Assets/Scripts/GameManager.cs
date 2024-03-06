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
}

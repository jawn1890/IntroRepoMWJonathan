using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    //IN CLASS SCRIPT CCNY MW
    //GLOBAL VARIABLES
    public float timeRemaining = 90;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public bool ifGameOver= false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if timer is running, do all of the following code- if not, don't run it.
        //nesting if statements

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; //Unity specific variable that rerpresents the time in seconds from the previous from to the current time.
            }
            else if (timeRemaining <= 0)
            {
            Debug.Log("time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;

            }
        }
        DisplayTime();
        

        //Debug.Log("timeRemaining = " + timeRemaining);
        
    }

    void DisplayTime()
    {
        //FloorToInt takes a float and rounds it DOWN-ALWAYS- to the nearest whole Integer.
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //could you make the timer change to text? or would it be easier to simply display a separate text element altogether?




    }



}

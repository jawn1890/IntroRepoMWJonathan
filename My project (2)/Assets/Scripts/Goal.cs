using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //CCNY MW Class
    // GLOBAL VARIABLES

    public bool isPlayer1Goal;
    public GameManager myManager;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log("ball in trigger");
            if (isPlayer1Goal)
            {
                myManager.Player2Scored();
            }
            else
            {
                myManager.Player1Scored();
            }

        }

    }



}

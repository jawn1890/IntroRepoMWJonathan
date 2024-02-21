using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //MW in Class
    //GLOBAL VARIABLES
    public Rigidbody2D rbPaddle;
    public bool isPlayer1;
    public float paddleSpeed = 0.05f; //This is a really low number so the paddles dont go flying.


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Paddle Script! Woop!");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            Player1Control();
        }
        else
        {
            Player2Control();
        }
        
    }

    void Player1Control()
    {
        //Debug.Log("is player 1");
        Vector3 newPos = transform.position;
        if (newPos.y <=4.1f && newPos.y >= -4.1f)
        {
                    //PLAYER MOVEMENT CONTROLS
            //UNITY has some player movement controllers built in

            if(Input.GetKey(KeyCode.W))
            {
                //Debug.Log("W key Pressed!");
                newPos.y += paddleSpeed;

            } else if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("S key Pressed!");
                newPos.y -= paddleSpeed;
            }
            transform.position = newPos;
        }

        if (newPos.y >= 4.1f)
        {
            newPos.y = 4;
            transform.position = newPos;
        }
        else if (newPos.y <= -4.1f)
        {
            newPos.y = -4;
            transform.position = newPos;
        }

    }

    void Player2Control()
    {
        //Debug.Log("is player 2");
Vector3 newPos = transform.position;
        if (newPos.y <=4.1f && newPos.y >= -4.1f)
        {
                    //PLAYER MOVEMENT CONTROLS
            //UNITY has some player movement controllers built in

            if(Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("W key Pressed!");
                newPos.y += paddleSpeed;

            } else if (Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("S key Pressed!");
                newPos.y -= paddleSpeed;
            }
            transform.position = newPos;
        }

        if (newPos.y >= 4.1f)
        {
            newPos.y = 4;
            transform.position = newPos;
        }
        else if (newPos.y <= -4.1f)
        {
            newPos.y = -4;
            transform.position = newPos;
        }

    }
}

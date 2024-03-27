using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Homework for Wednesday 3/6:
//try making it so that when you collide with a wall, you don't keep going. (work in the OnTriggerEnter2D void)
//try making it so that only one piece of food spawns
//try making it so that other button presses trigger events (button for boost after collecting an item- but maybe too ambitious for Wednesday)
//try making it so that...




public class Snake : MonoBehaviour
{
    //MW Class CCNY
    //GLOBAL VARIABLES
    
    
    Vector3 dir = Vector3.right; //think of Vector3 as a line with an arrow on it- like a direction
                                 //There are shorthands for Vector3 directions

    //Keep Track of Tail Elements
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    
    //I initially declared a variable called crash to be checked if it was true or not and then
    //I would have the game execute code to reset the snake and score to 0.
    //However, upon further discussion, professor Smith mentioned that it might be more efficient
    //to create a new function (perhaps called crashed) and just call it when a wall is collided with!
    //bool crash = false;
    public GameObject tailPrefab;
    public GameManager myManager;//References the GameManager script in the inspector.
    //how do I do something like this with the spawn function? or how do you use a bool to solve this?

    public Vector3 snakeStartPos = Vector3.zero;
    public FoodSpawn foodSpawnScript;
    float snakeSpeed = 0.03f;
    //public bool speedBoost = false;

    



    
    // Start is called before the first frame update
    void Start()
    {
        //Changing the floats (like 0.1f) in this line of code will speed up the snake!
        InvokeRepeating("MoveSnake", snakeSpeed, snakeSpeed);


    }

    // Update is called once per frame
    void Update()
    {

        //MoveSnake();
        ChangeDirection();

        if (Input.GetKey(KeyCode.Space))
        {
            snakeSpeed = 0.03f;
        }
        

    }



    void MoveSnake()
    {
        //how to pull the last item from the list and get the transform positiion and add it to the front of the list??
        //look up different ways of using lists in C# with System.Linq

        Vector3 gap = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            //Debug.Log("ate =" + ate);

            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);

            ate = false;
            //You only get a piece of tail when you eat a piece of food lollll
        

        }

        //Check if snake has a tail
        else if (tail.Count > 0)
        {
            //Move the last Tail piece to where the Head previously was
            tail.Last().position = gap;

            //Keep our Tail list in order!
            //Add Last Tail element to the front of the list and remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);

        }

    }

    void Crashed()
    {
            //Debug.Log("function being called");       
            transform.position = snakeStartPos; //Set snake position back to start
            myManager.foodScore = 0; //reset foodscore to 0
            
            //Lunch attempt
            //dir = Vector3.zero;
            //Invoke("MoveSnake", 0.3f);


            //Older attempts  below

            //myManager.ObstacleHit();


            //Tried this,  didnt work! vvv
            //Destroy(tailSec);
            //Also didnt work!! vvv
            //DestroyImmediate(tailPrefab, true);

        //Attempting to reset snake position
        // if (crash == true)
        // {
            
        //     //crash = false; //set inPlay to true
            

        // }
    }






    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector3.down;
        }

        //for these next lines (to try to speed up my snake) I probably need to store the velocity
        //of the snake as an int (or float?) and then multiply that value by 2 rather than trying
        //to multiply the shortcut by 2 (cuz it's like a command rather than a number?) but lets see!

        //did not work!
        // if (Input.GetKey(KeyCode.LeftArrow) && myManager.foodScore = 10)
        // {
        //     Debug.Log("Speeding up left");
        //     //dir = Vector3.left * 2;
        // } 
        // else if (Input.GetKey(KeyCode.RightArrow) && myManager.foodScore == 10)
        // {
        //     Debug.Log("Speeding up right");
        //     //dir = Vector3.right * 2;
        // }
        // else if(Input.GetKey(KeyCode.UpArrow) && myManager.foodScore == 10)
        // {
        //     Debug.Log("Speeding up up");
        //     //dir = Vector3.up * 2;
        // }
        // else if (Input.GetKey(KeyCode.DownArrow) && myManager.foodScore == 10)
        // {
        //     Debug.Log("Speeding up down");
        //     //dir = Vector3.down * 2;
        // }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            ate = true;
            //Debug.Log("Food Eaten!!");
            Destroy(collision.gameObject);
            //Back in the Unity Editor, we edited the box collider on the HEAD so that the collider wasn't at the edges 
            //(you can select the head in the hierarchy, go to boxCollider2D --> Edit Collider button --> and Scale the collider
            //from wrapping around the edges to being ever so slightly away from all edges)
            //This way, when passing by the food, the collision event will not trigger. It will only trigger when the head goes fully over the food.
            //The scale of both HEAD and FOOD are the same, so slightly scaling down the box collider will not affect anything because everything IS and IS MOVING AT 1px x 1px.
            myManager.FoodEaten();
            foodSpawnScript.Spawn(); //spawns the food only after the previous piece is eaten- calls Spawn() from the FoodSpawn script!

            //trying to make the snake speed up when it eats food
            //did not work, will try to set a global variable when this collision happens
            snakeSpeed = snakeSpeed - 0.9f;
            Debug.Log("current snakeSpeed is " + snakeSpeed);

            //myManager.FoodSpawn(); tried these but they didn't work!
            //Invoke("Spawn", 1);
        


        }
        else if (collision.gameObject.tag == "Wall")
        {

            //Do something!!
            //I'll need to create a startPos for the snake and then reset it when I hit the walls.
            //I already tagged each wall as "Wall" so just continue from there!
            //Debug.Log("collided!!!");

            //Did not work!!!! vvv
            //tail.Count = 0;
            Crashed(); //How do I get the whole tail/tail list to disappear or for a game over screen to appear?

            
        }
    }



}

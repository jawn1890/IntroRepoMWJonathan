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
    public GameManager myManager;

    public Vector3 snakeStartPos;
    



    
    // Start is called before the first frame update
    void Start()
    {
        //Changing the floats (like 0.1f) in this line of code will speed up the snake!
        InvokeRepeating("MoveSnake", 0.03f, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        //MoveSnake();
        ChangeDirection();

        




    }

    void MoveSnake()
    {
        //how to pull the last item from the list and get the transform positiion and add it to the front of the list??
        //look up different ways of using lists in C# with System.Linq

        Vector3 gap = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            Debug.Log("ate =" + ate);

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
            Debug.Log("function being called");       
            transform.position = snakeStartPos; //Set snake position back to start
            myManager.foodScore = 0; //reset foodscore to 0
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
            //tried this vvvv but it didn't work!
            //myManager.FoodSpawn();
        


        }
        else if (collision.gameObject.tag == "Wall")
        {

            //Do something!!
            //I'll need to create a startPos for the snake and then reset it when I hit the walls.
            //I already tagged each wall as "Wall" so just continue from there!
            Debug.Log("collided!!!");

            //Did not work!!!! vvv
            //tail.Count = 0;
            Crashed(); //How do I get the whole tail/tail list to disappear or for a game over screen to appear?

            
        }
    }



}

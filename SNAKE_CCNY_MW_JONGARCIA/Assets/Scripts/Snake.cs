using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Include this library for managing lists.

//MW In Class CCNY

//MIDTERM PROJECT 3/28/2024 Jonathan Garcia



public class Snake : MonoBehaviour
{

//Homework for Wednesday 3/6:
//try making it so that when you collide with a wall, you don't keep going. (work in the OnTriggerEnter2D void)
//try making it so that only one piece of food spawns
//try making it so that other button presses trigger events (button for boost after collecting an item- but maybe too ambitious for Wednesday).


    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right; //think of Vector3 as a line with an arrow on it- like a direction
    //There are shorthands for Vector3 directions
    
    //Keep Track of Tail Elements
    List<Transform> tail = new List<Transform>();
    bool ate = false; //Used to check if we've eaten a piece of food.
    
    public GameObject tailPrefab; //References the tailPrefab (which is also the head) in the Inspector.
    public GameManager myManager; //References the GameManager script in the inspector.
    public FoodSpawn foodSpawnScript; //Allows this script to communicate with the FoodSpawn script.
    public SceneChanger changeScene; //Attempting to use this to change the scenes like our point and click game, but it isn't fully working for some reason.
    
    public float snakeSpeed = 1.0f; //A variable to try to control the speed of the snake- also not quite working.
    public bool snakeIsDead = false; //Attempting to use this as a way to reset the snake with a button press.
    //Ideally I would like to use the snake hitting a wall to trigger a scene change, so this wouldn't be necessary.

    



    
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("MoveSnake", 0.03f, snakeSpeed); //Changing the floats in this line of code will alter the speed of the snake.
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ChangeDirection(); //This method is being called every frame to check if we are changing the direction of the snake.

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
            //If we eat a piece of food (ate = true), the 2 lines below will run and Instantiate a new tail piece and put it in the gap after the head piece.
            //This creates a tail that is always following us and constantly growing based on how much food we eat.
            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);

            snakeSpeed = 0.05f; //Trying to speed up the snake after a piece of food is eaten. Works if you manually change the value in the inspector, but not in the code.
            //Which did you say overrides which again? Inspector or code? Perhaps it's because it's public as opposed to serialized that we werent able to change this value with the code alone?

            ate = false; //You only get a piece of tail added when you eat a piece of food.
            //This ensures ate doesn't stay true and keep replicating the tail indefinitely.
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



    private void ChangeDirection()
    {
        //This is the code being constantly called in Update- this changes the direction of the Vector3 dir using shorthand for each direction.
        //Additionally, dir will only change here when any of the arrow keys are pressed and continue until the next key is pressed.

        //Pressing the Left Arrow key moves the snake left.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector3.left;
        }
        //Pressing the Right Arrow key moves the snake right.
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector3.right;
        }
        //Pressing the Up Arrow key moves the snake up.
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector3.up;
        }
        //Pressing the Down Arrow key moves the snake down.
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector3.down;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //These blocks of code execute when collisions happen. The if statements check if the conditions are true.

        //If the snake collides with (eats) a piece of food...
        if (collision.gameObject.tag == "Food")
        {
            
            ate = true; //Ate is set to true.

            //Debug.Log("Food Eaten!!");
            Destroy(collision.gameObject); //The piece of food is destroyed (removed from the play area).

            //Back in the Unity Editor, we edited the box collider on the HEAD so that the collider wasn't at the edges 
            //(you can select the head in the hierarchy, go to boxCollider2D --> Edit Collider button --> and Scale the collider
            //from wrapping around the edges to being ever so slightly away from all edges)
            //This way, when passing by the food, the collision event will not trigger. It will only trigger when the head goes fully over the food.
            //The scale of both HEAD and FOOD are the same, so slightly scaling down the box collider will not affect anything because everything IS and IS MOVING AT 1px x 1px.

            myManager.FoodEaten(); //The FoodEaten method is called from the GameManager script and increases the score visible to the player by 1.
            foodSpawnScript.Spawn(); //Finally, the Spawn method is called from the FoodSpawn script to spawn a new piece of food randomly between the walls.

        }

        //I created a green poison prefab in Unity; here, I am running code when the snake collides with a piece of poison.
        else if (collision.gameObject.tag == "Poison")
        {
            Destroy(collision.gameObject); //Make the poison go away.
            myManager.PoisonEaten(); //Calls the PoisonEaten method from the GameManager script and decreases the score visible to the player by 1.
            snakeSpeed = 1.0f; //Attempting to reset the speed back to 1 and slow it down if a piece of poison is eaten.

            //foodSpawnScript.SpawnPoison(); //This was just to check if the poison would spawn only after being eaten- and it works- but I did not want that feature implemented.
        }

        //This code will run if the snake hits a wall.
        else if (collision.gameObject.tag == "Wall")
        {
            
            CancelInvoke("MoveSnake"); //I ended up using this to fully stop the snake from moving. The way I was trying to reset the snake prior to CancelInvoke
            //was only allowing me to move the head back to the center but it would keep moving normally. Essentially, starting over but still moving.
            //Trying to change the value of dir to Vector3.zero made the snake stop moving in place but I could simply start moving again using the Arrow keys.

            //I would need to spend some more time to reset the snake after deleting my method called Crashed(). It seemed clunky, but I will actually try to find
            //that code again in github to add it back for this.

            //I tried to use the following 2 lines of code to try to change the scene after hitting the wall.
            //I did what we did for the point and click, but I can't get through the second and third scenes. I am only able to switch from the start scene to the gameplay scene.
            //I tried to even make an override key press (as a sort of debug to make sure it would still work- since I wanted the collision to trigger the scene change) and it didn't work either.
            //changeScene.snakeDead = true;
            //changeScene.SnakePlaySceneControls();

            //My original collision detection debug log.
            //Debug.Log("collided!!!");
            
        }
    }



}

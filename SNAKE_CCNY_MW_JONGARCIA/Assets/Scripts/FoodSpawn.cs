using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MW In Class CCNY

//MIDTERM PROJECT 3/28/2024 Jonathan Garcia



public class FoodSpawn : MonoBehaviour
{

    //CCNY MW CLASS SPRING24

    //GLOBAL VARIABLEs
    public GameObject foodPrefab; //Used to add the food prefabs to the Game Manager in the Inspector.
    public GameObject poisonPrefab; //Used to add the poison prefabs to the Game Manager in the Inspector.

    //BORDER POSITIONS
    //Used to get the position of each wall so that we can spawn the food and poison INSIDE the game area. Otherwise, the food and poison would spawn out of bounds.
    public Transform wallTop;  
    public Transform wallBottom;
    public Transform wallLeft;
    public Transform wallRight;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 1); //As soon as the game starts, spawn a piece of food only once after 1 second. Spawn in quotes refers to the name of the Spawn method below.
        InvokeRepeating("SpawnPoison", Random.Range(10.0f, 20.0f) ,Random.Range(10.0f, 20.0f)); //Spawn a piece of poison at a random time between 10 and 20 seconds after the game starts, and repeat for a random amount of time between 10 and 20 seconds.
        //This both slows down and randomizes the spawn rate of the poison, but also keeps it continuously spawning.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Created a new public void to be used in this and other scripts.
    public void Spawn()
    {
        //Debug.Log("Spawn Called!"); //Checking to see if it works when called.

        int xPos = (int)Random.Range(wallLeft.position.x + 1, wallRight.position.x - 1); //Declare and initialize an x value at a random position between the left and right walls (on the x axis)
        int yPos = (int)Random.Range(wallTop.position.y - 1, wallBottom.position.y + 1); //Declare and initialize a y value at a random position between the top and bottom walls (on the y axis)

        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); //Instantiate a new piece of food with those x and y values and keep its rotation with Quaternion.identity (no identity crises when spawning new food!)


    }

    //Doing the same thing for the poison pieces. I amended the x and y names to xPos2 and yPos2 as not to confuse the code and anyone reading it.
    public void SpawnPoison()
    {
        //Debug.Log("SpawnPoison Called!");

        //Set the x and y values randomly between the walls. I used wallLeft.position.x +1 etc. to ensure that the food and posion spawn only BETWEEN the walls and not directly UNDER the walls.
        int xPos2 = (int)Random.Range(wallLeft.position.x + 1, wallRight.position.x - 1);
        int yPos2 = (int)Random.Range(wallTop.position.y - 1, wallBottom.position.y + 1);

        //Instantiate new poison with xPos2 and yPos2 values and keep its rotation with Quaternion.identity.
        Instantiate(poisonPrefab, new Vector3(xPos2, yPos2, 0), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{

    //CCNY MW CLASS SPRING24

    //GLOBAL VARIABLEs
    public GameObject foodPrefab;

    //BORDER POSITIONS
    public Transform wallTop;
    public Transform wallBottom;
    public Transform wallLeft;
    public Transform wallRight;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 1);
        //InvokeRepeating("Spawn", 3, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //Debug.Log("Spawn Called!");

        int xPos = (int)Random.Range(wallLeft.position.x + 1, wallRight.position.x - 1);
        int yPos = (int)Random.Range(wallTop.position.y - 1, wallBottom.position.y + 1);

        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);


    }
}

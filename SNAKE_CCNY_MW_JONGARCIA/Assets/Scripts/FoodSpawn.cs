using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{

    //CCNY MW CLASS SPRING24

    //GLOBAL VARIABLEs
    public GameObject foodPrefab;
    bool ate = false;

    //BORDER POSITIONS
    public Transform wallTop;
    public Transform wallBottom;
    public Transform wallLeft;
    public Transform wallRight;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 4);
        //InvokeRepeating("Spawn", 3, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //Debug.Log("Spawn Called!");

        int xPos = (int)Random.Range(wallLeft.position.x, wallRight.position.x);
        int yPos = (int)Random.Range(wallTop.position.y, wallBottom.position.y);

        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);


    }
}

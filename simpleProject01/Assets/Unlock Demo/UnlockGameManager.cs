using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockGameManager : MonoBehaviour
{
    public static UnlockGameManager Singleton;
    public GameObject Door;
    public TextMeshPro Text;
    public LockBoxScript BoxPrefab;
    public static int score = 0;

    void Start()
    {
        Singleton = this;
        //This code would spawn three lockboxes at random spots
        //How could we make it so you need to unlock all to open the door?
        for (int n = 0; n < 3; n++)
        { 
            Instantiate(BoxPrefab, new Vector3(Random.Range(-7f, 3), 
                Random.Range(-4f, 4), 0), Quaternion.identity);
        }
    }
    
    public void UnlockDoor()
    {
        Door.gameObject.SetActive(false);
    }
}

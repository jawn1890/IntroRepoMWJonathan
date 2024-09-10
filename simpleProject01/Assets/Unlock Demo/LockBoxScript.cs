using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxScript : MonoBehaviour
{
    public SpriteRenderer SR;
    public GameObject Door;


    void Start()
    {
        //Door = GameObject.FindObjectOfType<DoorScript>;
    }
    void Update()
    {
        //Right now, if we hit space we unlock
        //How could we make it only unlock if we hit the TestPlayer?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Unlock();
        }
    }

    //All the code for unlocking goes here
    //How do we make the door actually open when we unlock?
    public void Unlock()
    {
        SR.color = Color.green;
        Destroy(UnlockGameManager.Singleton.Door.gameObject);
    }
}

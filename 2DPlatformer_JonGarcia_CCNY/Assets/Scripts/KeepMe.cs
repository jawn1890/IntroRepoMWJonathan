using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{

    //In Class CCNY MW
    //GLOBAL VARIABLES
    public static GameObject instance; //static variables are shared by all instance of a class. when outside of the loaded scene or out of scope, the object will retai its values.
    //although public, this variable will not appear in the inspector.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() //when the new scene or instance of this script loads...
    {
        if (instance == null) // if the instance of the game object that this script is attached to does not exist when the new scene starts...
        {
            //Debug.Log("Audio Manager Not Destroyed"); //print a debug message to the console to say that the audio manager is not destroyed.
            instance = gameObject; //the new statiis instance becomes equal to this game object and therefore it now exists.
            DontDestroyOnLoad(gameObject); //don't destroy the target gameobject when loading a nnew scene. this will ensure that our audiio plays continuously whenever scenes are changed.
        }
        else //if the instance already exists in the scene...
        {
            //Debug.Log("Extra Audio Manager Destroyed"); //debug log printed to the console to tell us that the duplicated audio manager is destroyed. this way, the audio wont be doubled over itself.
            Destroy(gameObject); //destroy the extra audio manager and keep the current one. use can use this to keep many things consistent across scenes, not just audio.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

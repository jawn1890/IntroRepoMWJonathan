using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    //Making a public static reference to be accessed anywhere, throughout the code
    public static GameManager Me;
    
    //Prefab for spawning the monster (so you don't have a bunch of actual monster objects in the scene)
    public EnemyScript EnemyPrefab;
    
    //How long until the next monster spawns?
    public float SpawnTimer = 0;
    
    //Once a monster spawns, how long until the next one spawns?
    public float SpawnTimerMax = 3;
    
    //Where do the monsters spawn?
    public Vector3 EnemySpawnPos;
    
    //A link to the player
    public PlayerController Player;
    
    //Keep a list of all the monsters
    public List<EnemyScript> AllEnemies;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Register myself to the static variable
        GameManager.Me = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn timer always counts down in real time
        SpawnTimer -= Time.deltaTime;
        //When the timer hits 0...
        if (SpawnTimer <= 0)
        {
            //Reset the spawn timer
            SpawnTimer = SpawnTimerMax;
            //Spawn enemy at the SpawnEnemyPos location
            EnemyScript e = Instantiate(EnemyPrefab, EnemySpawnPos, Quaternion.identity);
            // 50/50 chance the enemy will turn around
            if (Random.Range(0, 1f) < 0.5f)
            {
                e.TurnAround();
            }

        }
    }
}

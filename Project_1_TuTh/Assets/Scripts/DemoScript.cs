using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DemoScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    public TextMeshPro Text;
    public int Score = 0;
    public float Timer = 3;


    public GameObject CoinPrefab;
  
    void Update()
    {
        Text.text = "Score: "+Score;


        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Vector3 where = new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0);
                Instantiate(CoinPrefab, where, Quaternion.identity);
                Timer = 3;
            }
        }


        //Make a variable of the type
        Vector2 vel = new Vector2(0,0);
        //Figure out the value you want it to have
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = 5;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -5;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = 5;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -5;
        }


        //Plug it into the component
        RB.velocity = vel;
      
      
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Score++;
        Destroy(other.gameObject);
    }
}

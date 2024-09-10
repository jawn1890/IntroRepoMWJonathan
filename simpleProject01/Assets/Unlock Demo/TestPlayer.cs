using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody2D RB;

    void Update()
    {
        //This is some pretty standard movement code
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
            vel.x = Speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            vel.x = -Speed;
        if (Input.GetKey(KeyCode.UpArrow))
            vel.y = Speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            vel.y = -Speed;
        //But we're missing a step.
        //How do we find the Rigidbody so we can tell it its velocity?
        RB.velocity = vel;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        LockBoxScript box = other.gameObject.GetComponent<LockBoxScript>();
        if (box != null)
        {
            box.Unlock();
        }
    }
}

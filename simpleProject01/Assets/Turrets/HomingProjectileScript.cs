using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectileScript : MonoBehaviour
{
    //How fast I move
    public float Speed = 10;
    //How fast I turn, higher means more accurate
    public float TurnSpeed = 2;

    //The rotation I want to have to hit my target
    public float DesiredRot = 0;
    
    //My rigidbody
    public Rigidbody2D RB;
    //The thing I'm zooming towards
    public GameObject Target;
    
    void Start()
    {
        //If I don't have a target, chase the player
        if(Target == null)
            Target = PlayerMovement.Player.gameObject;
    }

    void Update()
    {
        //Find the offset
        Vector3 pos = Target.transform.position - transform.position;
        //Use that offset to calculate the rotation we should have
        DesiredRot = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        
        //Rotate a % of the way towards facing the target.
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(0,0,DesiredRot),TurnSpeed*Time.deltaTime );
        
        //Fly forwards
        RB.velocity = transform.right * Speed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //If I hit something, vanish
        Destroy(gameObject);
    }
}

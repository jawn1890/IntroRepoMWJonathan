using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    //Projectile to spawn
    public GameObject ProjPrefab;
    //How fast do we shoot projectiles?
    public float RateOfFire = 1;
    //Countdown to shoot the next projectile
    public float Timer = 0;
    
    public GameObject Target;
    
    void Update()
    {
        //Find the offset between the player and turret
        Vector3 pos = Target.transform.position - transform.position;
        //Use that offset to calculate the rotation we should have
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        //Apply that rotation
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //Countdown the timer and shoot a bullet when time's up
        Timer += Time.deltaTime;
        if (Timer >= RateOfFire)
        {
            Timer = 0;
            Instantiate(ProjPrefab, transform.position, transform.rotation);
        }
    }
}

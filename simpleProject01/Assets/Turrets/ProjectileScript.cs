using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float Speed = 10;

    private void Start()
    {
        //When the projectile spawns, it goes flying in the direction it's facing
        //The shooter sets the rotation when it spawns
        RB.velocity = transform.right * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If I hit something, stop existing
        Destroy(gameObject);
    }
}

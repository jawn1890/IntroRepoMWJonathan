using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //IN CLASS CCNY MW

    //GLOBAL VARIABLE
    public Slider slider; //creating a slider component to be edited i the inspector.




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health) //setting max health, function takes an integer.
    {
        slider.maxValue = health; //setting the max value to be our starting health.
        slider.value = health;
    }

    public void SetHealth(int health) //setting current health dynamically
    {
        slider.value = health;
    }



}

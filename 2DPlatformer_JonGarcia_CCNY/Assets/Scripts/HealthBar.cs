using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //IN CLASS CCNY MW

    //GLOBAL VARIABLE
    public Slider slider;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health) //setting max health
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) //setting current health dynamically
    {
        slider.value = health;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseScript : MonoBehaviour
{
    //This script makes an object move from point A to B
    //You can change the Ease variable to make it move in different ways
    //This movement style will always take exactly Duration seconds to play
    //You can find more equations for other easing styles at https://easings.net/
    
    //My start position
    public Vector3 StartPos;
    //My end position
    public Vector3 Dest;
    //How far along I am
    //When this hits 1 I'm at my target
    public float Timer = 0;
    //How long it'll take me to hit the target
    public float Duration = 1f;
    //Which style of easing should I use?
    public Easings Ease = Easings.EaseInOutSin;

    void Start()
    {
        //Record my start position
        StartPos = transform.position;
    }
    
    void Update()
    {
        //Every frame, make time go up.
        //I divide it by Duration so that it takes Duration seconds to hit 1
        Timer += Time.deltaTime / Duration;
        //I run my timer through an equation that will give my movement a specific feel
        //If I feed it a 0 it will always return a 0, 1 will always return 1,
          //but between will have different curves
        float t = CalculateEase(Timer);
        //Set my locaiton to be t% of the way between my start and end point
        transform.position = Vector3.Lerp(StartPos,Dest,t);
    }

    //Try setting Ease to different settings to see what each of these are like
    public float CalculateEase(float x)
    {
        //If I went past the target, stop moving
        if (x > 1) x = 1;
        if (Ease == Easings.Linear) return x;
        if (Ease == Easings.EaseInSin) 
            return 1 - Mathf.Cos((x * Mathf.PI) / 2);
        if (Ease == Easings.EaseOutSin) 
            return Mathf.Sin((x * Mathf.PI) / 2);
        if (Ease == Easings.EaseInOutSin) 
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        if (Ease == Easings.EaseInExpo) 
            return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);;
        if (Ease == Easings.EaseInElastic) 
            return (x == 0 ? 0 : x == 1 ? 1 : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * ((2 * Mathf.PI) / 3)));
        return x;
    }
}

//A list of options
public enum Easings
{
    Linear,
    EaseInSin,
    EaseOutSin,
    EaseInOutSin,
    EaseInExpo,
    EaseInElastic,
}
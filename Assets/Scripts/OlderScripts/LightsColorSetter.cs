using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightsColorSetter : MonoBehaviour, DayNightInterface
{
    // Start is called before the first frame update
    public Gradient gradient;
    public UnityEngine.Rendering.Universal.Light2D[] lights;

    

    // Update is called once per frame
    

    void DayNightInterface.GetComponent()
    {
        lights = GetComponentsInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    void DayNightInterface.SetParameter(float time)
    {
       
        foreach (var light in lights)
        {
            light.color = gradient.Evaluate(time);
        }
    }
}

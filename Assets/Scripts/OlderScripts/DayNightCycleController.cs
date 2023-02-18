using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DayNightInterface
{
    void GetComponent();
    void SetParameter(float time);
}

[ExecuteInEditMode]
public class DayNightCycleController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 1)]
    public float time;
    public DayNightInterface[] setters;
    public bool day;

    private void OnEnable()
    {
        time = 0.1f;
        day = true;
        GetSetters();
    }

    private void GetSetters()
    {
        setters = GetComponentsInChildren<DayNightInterface>();
        foreach(var setter in setters)
        {
            setter.GetComponent();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(setters.Length > 0)
        {
            foreach(var setter in setters)
            {
                setter.SetParameter(time);
            }
        }

       
    }
}

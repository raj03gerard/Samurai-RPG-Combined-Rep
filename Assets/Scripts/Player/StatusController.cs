using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : Stats
{
    public string type = "Poison";
    public bool status = false;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("OnTriggerEnter2D");
        SpecialStatusController specialStatusController = collider2D.GetComponent<SpecialStatusController>();
        if (specialStatusController != null)
        {
            switch (type)
            {
                case "HP":
                    base.IncreaseHealth(50);//TODO no hardcode
                    Log("50 HP restore");
                    break;
                case "Speed":
                    float rate = 1;
                    if (!status)
                    {
                        rate = 0.7f;
                        Log("Speed reduced!");
                    }
                    specialStatusController.setSpeedReductionRate(rate);
                    break;
                default:
                    specialStatusController.status(type, status);
                    break;
            }

            Destroy(gameObject);
        }
    }
}

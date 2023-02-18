using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialStatusController : Stats
{
    public float statusDamageInterval = 1;

    private bool is_poisoned = false;
    private bool has_shield = false;
    private int shieldDurability = 0;
    private float timeForStatusDamage = 0;
    private float speed_reduction_rate = 1;

    private void FixedUpdate()
    {
        //if the player is poisoned will lose 5% of thier healt every second until is cured 
        if (is_poisoned)
        {
            if (timeForStatusDamage > 0)
            {
                timeForStatusDamage -= Time.deltaTime;
            }
            else
            {
                DecreaseHealth(Convert.ToInt32(Math.Ceiling(getHealth() * 0.05)), false);
                timeForStatusDamage = statusDamageInterval;
            }
        }
    }

    public void DecreaseHealth(int damage, bool is_attack)
    {
        //the shield only protecks from attacks, not from condition damage i.e: poison.
        if (has_shield && is_attack)
        {
            //the shield will be damage by half of the attack damage
            shieldDurability -= Convert.ToInt32(Math.Ceiling(damage * 0.5));
            if (shieldDurability <= 0)
            {
                has_shield = false;
            }
        }
        else
        {
            base.DecreaseHealth(damage);
        }
    }

    // string type: status name
    // bool giveStatus: true if the status is added false if removed
    public void status(string type, bool giveStatus)
    {
        switch (type)
        {
            case "Poison":
                is_poisoned = giveStatus;
               // if (is_poisoned)
                    //playerinfo("You're poisoned!");
               // else
                    //playerinfo("Cured from poison!");
                break;
            case "Shield":
                has_shield = giveStatus;
                shieldDurability = 50;
               // playerinfo("You got a shield!");
                break;
            default:
                break;
        }
    }

    public void setSpeedReductionRate(float rate)
    {
        speed_reduction_rate = rate;
    }
}

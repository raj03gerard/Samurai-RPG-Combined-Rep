using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxToWeapon : MonoBehaviour
{
    private AggressiveWeapon weapon;

    private void Awake()
    {
        weapon = GetComponentInParent<AggressiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D");

        weapon.AddToDetected(collision);
        if (collision.CompareTag("Enemy"))
        {
            Combat combatobj = collision.GetComponent<Combat>();
            if (combatobj)
            {
                Debug.Log(combatobj.name + "Object hit");
               
            }
            else Debug.Log("Combat obj not detected");
            
           

                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("OnTriggerExit2D");

        weapon.RemoveFromDetected(collision);
    }
}

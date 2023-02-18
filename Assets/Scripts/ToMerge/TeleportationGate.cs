using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationGate : MonoBehaviour
{
    public float destinationX=0;

    public float destinationY=0;

   void OnTriggerEnter2D(Collider2D collider2D)
    {
        //PlayerController playerController = collider2D.GetComponent<PlayerController>();
       // if (playerController != null)
        {
            //-*-*-*-* playerController.setPosition(destinationX, destinationY);
            //-*-*-*-* playerController.levelUp();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Hurt : MonoBehaviour
{
    Enemy1 enemy;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Weapon"))
        {
            Debug.Log("Hurt by player");

           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Combat combatComponent = collision.gameObject.GetComponentsInChildren<Combat>()[0];
            Movement movementComponent = collision.gameObject.GetComponentsInChildren<Movement>()[0];
            combatComponent.Damage(5);
            combatComponent.Knockback(new Vector2(20, 20), 15, -movementComponent.FacingDirection);
        }
    }
}

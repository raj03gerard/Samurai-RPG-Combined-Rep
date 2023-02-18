using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float attackInterval = 2;
    public bool canShoot = false;
    public bool canMove = false;
    public float speed;
    public float jumpForce = 500F;


    public float timeForNextAttack = 0;
    public Rigidbody2D rigidBody2D;
    public AttackController attackController;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        attackController = this.GetComponent<AttackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) {
            Vector3 targetVelocity = new Vector2(speed, rigidBody2D.velocity.y); 
            
            rigidBody2D.velocity = targetVelocity;
        }
        if (timeForNextAttack > 0)
        {
            timeForNextAttack -= Time.deltaTime;
        }
        else
        {
            if (canShoot)
            {
                attackController.throwProjectile();
            }
            attackController.meleeAtack();
            timeForNextAttack = attackInterval;
        }

    }
}

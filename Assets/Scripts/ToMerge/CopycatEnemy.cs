using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopycatEnemy : EnemyController
{
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (timeForNextAttack > 0)
        {
            timeForNextAttack -= Time.deltaTime;
        }
        else
        {
            Vector3 targetVelocity = new Vector2(0, 0);
            rigidBody2D.velocity = targetVelocity;
            int rand = Random.Range(1, 4);
            switch (rand)
            {
                case 1:
                    Debug.Log("Move");
                    targetVelocity = new Vector2(speed, rigidBody2D.velocity.y);

                    rigidBody2D.velocity = targetVelocity;
                    break;
                case 2:
                    Debug.Log("Attack");
                    attackController.meleeAtack(20);
                    break;
                case 3:
                    Debug.Log("Jump");
                    rigidBody2D.AddForce(new Vector2(0f, jumpForce));
                    break;                   
                default:
                    break;
            }
            attackController.meleeAtack(20);
            timeForNextAttack = attackInterval;
        }

    }
}

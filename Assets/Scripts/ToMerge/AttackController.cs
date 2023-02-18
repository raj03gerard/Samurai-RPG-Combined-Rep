using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    public Animator animator;
    public LayerMask targetLayers; //Enamy layer if the player is attacking player layer if the enemy is.
    public float attackRange = 2f;
    public Transform attackPoint;
    public GameObject projectile;


    public void meleeAtack()
    {
        meleeAtack(0);
    }
    
    public void meleeAtack(float modifier)
    {
        int baseAttack = 20;
        animator.SetTrigger("Attack");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
        foreach (Collider2D targetCollider in colliders)
        {
            Stats targetHealth = targetCollider.GetComponent<Stats>();
            if (targetHealth != null)
            {
                //the Game Object has a health bar, is a player/enemy, get hurt
                targetHealth.DecreaseHealth(Convert.ToInt32(Math.Ceiling(baseAttack * (1 + modifier))));
            }
            else {
                //the Game Object dosen't have a health bar, is a Breakable object, destroy
                //-*-*-*-* targetCollider.GetComponent<Projectile>().destroy();
            }
        }
    }

    public void throwProjectile()
    {
         Instantiate(projectile, attackPoint.position, attackPoint.rotation);
    }

    void OnDrawGizmosSelected() {
        if (attackPoint==null) 
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

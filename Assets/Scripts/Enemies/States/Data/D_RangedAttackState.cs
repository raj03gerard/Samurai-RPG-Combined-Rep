using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State")]
public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10f;
    public float midRangeAttackDamage=10f;
    public float midRangeAttackradius = 0.75f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance = 15f;
    public float LongRangeAttackDistance = 20f;
    public float MidRangeAttackDistance= 10f;
    public LayerMask whatIsPlayer;
    public float knockbackStrength = 10f;

    public Vector2 knockbackAngle = Vector2.one;
}

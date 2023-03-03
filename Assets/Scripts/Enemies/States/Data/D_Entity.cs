using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxHealth = 40f;

    public float damageHopSpeed = 10f;

    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;

    public float stunResistance = 3f;
    public float stunRecoveryTime = 2f;

    public float minAgroDistance = 10f;
    public float maxAgroDistance = 20f;

    public float closeRangeActionDistance = 1f;
    public float midRangeActionDistance = 20f;
    public float longRangeActionDistance = 50f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}

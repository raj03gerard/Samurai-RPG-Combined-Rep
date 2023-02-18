using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Do not need it anymore
//public struct AttackDetails
//{
//    public Vector2 position;
//    public float damageAmount;
//    public float stunDamageAmount;
//}

[System.Serializable]
public struct WeaponAttackDetails
{
    public string attackName;
    public float movementSpeed;
    public float damageAmount;

    public float knockbackStrength;
    public Vector2 knockbackAngle;
}

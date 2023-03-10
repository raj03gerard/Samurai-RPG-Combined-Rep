using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObjectsManager : MonoBehaviour
{
    public enum CollectibleType { HealthOrb, CollectibleOrb };
    public CollectibleType collectibleType;
    public delegate void OnOrbCollected(int XP, CollectibleType collectibleType);
    public static event OnOrbCollected IncreaseTotalXP;
    
    public static void IncreasePlayerXP(int XP, CollectibleType collectibleType)
    {
        if (IncreaseTotalXP != null)
            IncreaseTotalXP(XP, collectibleType);
    }
}

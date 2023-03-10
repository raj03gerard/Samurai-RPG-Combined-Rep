using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAdditionalPlayerStatsData", menuName = "Data/Player Data/Additional Stats Data")]
public class PlayerAdditionalStatsData : ScriptableObject
{
    [Header("Experience Points")]
    public int totalXPCollected = 0;
}

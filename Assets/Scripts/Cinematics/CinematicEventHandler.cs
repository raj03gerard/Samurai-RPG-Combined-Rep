using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicEventHandler : MonoBehaviour
{
    public delegate void onCinematicFinished(GameManager.EnemyNames enemyName);
    public static event onCinematicFinished ShowBossPromptEvent;
    
    public static void CinematicAnimationFinished(GameManager.EnemyNames enemyNames)
    {
        ShowBossPromptEvent(enemyNames);
    }
}

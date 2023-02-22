using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mikoshi_Nyudo_Cinmeatic_Handler : MonoBehaviour
{
    public void OnCinmeaticAnimationOver()
    {
        CinematicEventHandler.CinematicAnimationFinished(GameManager.EnemyNames.Mikoshi_Nyudo);
    }
}

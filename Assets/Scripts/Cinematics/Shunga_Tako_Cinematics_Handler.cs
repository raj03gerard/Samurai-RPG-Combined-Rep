using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shunga_Tako_Cinematics_Handler : MonoBehaviour
{
    [SerializeField]
    GameObject AnimeLinesImg;

    private void Start()
    {
        AnimeLinesImg.SetActive(false);
    }
    public void PlayAnimeLinesEffect()
    {
        AnimeLinesImg.SetActive(true);
    }
    public void OnCinmeaticAnimationOver()
    {
        AnimeLinesImg.SetActive(false);
        CinematicEventHandler.CinematicAnimationFinished(GameManager.EnemyNames.Shunga_Tako);
    }
}

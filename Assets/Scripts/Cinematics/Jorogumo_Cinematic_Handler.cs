using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jorogumo_Cinematic_Handler : MonoBehaviour
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
        CinematicEventHandler.CinematicAnimationFinished(GameManager.EnemyNames.Jorogumo);
    }
}

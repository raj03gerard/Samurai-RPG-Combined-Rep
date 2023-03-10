using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollectibles : MonoBehaviour
{
    [SerializeField]
    Stats stats;
    [SerializeField]
    Combat combat;
    [SerializeField]
    GameObject GeneralOrbCollectParticlesContainer;

    private void OnEnable()
    {
        CollectibleObjectsManager.IncreaseTotalXP += IncreaseXP;
    }
    private void OnDisable()
    {
        CollectibleObjectsManager.IncreaseTotalXP -= IncreaseXP;
    }
   void IncreaseXP(int XP, CollectibleObjectsManager.CollectibleType collectibleType)
    {
        this.GetComponent<Player>().additionalStatsData.totalXPCollected += XP;
        if (collectibleType == CollectibleObjectsManager.CollectibleType.CollectibleOrb)
        {
            GeneralOrbCollectParticlesContainer.SetActive(true);
            StartCoroutine(DisableGeneralOrbCollectparticles());
        }
    }
    IEnumerator DisableGeneralOrbCollectparticles()
    {
        yield return new WaitForSeconds(2f);
        GeneralOrbCollectParticlesContainer.SetActive(false);
    }

}

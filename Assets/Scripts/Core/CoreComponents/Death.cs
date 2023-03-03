using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticle;

    private ParticleManager ParticleManager { get => particleManager ?? core.GetCoreComponent(ref particleManager); }
    private ParticleManager particleManager;

    private Stats Stats { get => stats ?? core.GetCoreComponent(ref stats); }
    private Stats stats;
    [SerializeField]
    GameObject HealthBarImage;
    [SerializeField]
    GameObject BossAreaBlocker;
    //Function which will disable the object the Death Core Component attached to.
    public void Die()
    {
        try
        {
            //instantiate some particles when object dies
            foreach (var particle in deathParticle)
            {
                ParticleManager.StartParticles(particle);
            }
        
            HealthBarImage.SetActive(false);
            BossAreaBlocker.SetActive(false);
        }
        catch
        {
            //No health bar image
        }
        core.transform.parent.gameObject.SetActive(false);
    }

    // In order to avoid errors, we should make sure that we subscribe to the event only when Death script is Enabled
    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}

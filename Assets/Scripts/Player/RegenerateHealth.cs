using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour
{
    [SerializeField]
    Stats stats;
    [SerializeField]
    Combat combat;
    [SerializeField]
    GameObject HealthRegenerateParticles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("HealthOrb"))
        {
            stats.IncreaseHealth(100f);
            combat.UpdateHealthBar();
            Debug.Log("Increase Health");
            Destroy(collision.gameObject);
            HealthRegenerateParticles.SetActive(true);
            StartCoroutine(DeactivateHealthRegenrateParticles());
        }
    }
    IEnumerator DeactivateHealthRegenrateParticles()
    {
        yield return new WaitForSeconds(2f);
        HealthRegenerateParticles.SetActive(false);
    }
}

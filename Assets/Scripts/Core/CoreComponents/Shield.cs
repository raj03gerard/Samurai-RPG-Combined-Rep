using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shield : CoreComponent, IBlockable
{
    [SerializeField]
    public bool canBeDamagedNow = true;

    [SerializeField]
    public bool canDeployShield = true;
    private bool isRegeneratingShield = false;
    private Stats Stats { get => stats ?? core.GetCoreComponent(ref stats); }
    private Stats stats;
    [SerializeField] private float shieldRefillSpeed = 20;
    [SerializeField] Image shieldBar;
    [SerializeField] Color defaultShieldColor;
    [SerializeField] ParticleSystem ShieldHitParticles;
    public override void LogicUpdate()
    {
        if (isRegeneratingShield)
            Stats?.IncreaseShield(shieldRefillSpeed * Time.deltaTime);

        if (Stats.currentShieldHealth < Stats.maxShield)
            isRegeneratingShield = true;

        if (Stats.currentShieldHealth <= Stats.maxShield * 0.3)
        {
            canDeployShield = false;
            shieldBar.color = Color.yellow;
        }
        else
        {
            canDeployShield = true;
            shieldBar.color = defaultShieldColor;
        }
        shieldBar.fillAmount = RemapValue(100, 0, 1, 0, Stats.currentShieldHealth);

    }
    public void DamageShield(float amount)
    {
        Stats?.DecreaseShield(amount);
        ShieldHitParticles.Play();
        Debug.Log(core.transform.parent.name + " Current Shield Health: " + Stats.currentShieldHealth);
    }
    public void ShieldDestroyed()
    {
        canDeployShield = false;
        isRegeneratingShield = true;
    }
    public void ShieldFullyRegenrated()
    {
        canDeployShield = true;
        isRegeneratingShield = false;
    }
    public float RemapValue(float oldMax, float oldMin, float newMax, float newMin, float valueToRemap)
    {
        float OldRange = (oldMax - oldMin);
        float NewRange = (newMax - newMin);
        float NewValue = (((valueToRemap - oldMin) * NewRange) / OldRange) + newMin;
        return NewValue;
    }
    private void OnEnable()
    {
        defaultShieldColor = shieldBar.color;
        Stats.OnShieldZero += ShieldDestroyed;
        Stats.OnShieldFull += ShieldFullyRegenrated;
    }

    private void OnDisable()
    {
        Stats.OnShieldZero -= ShieldDestroyed;
        Stats.OnShieldFull -= ShieldFullyRegenrated;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats : CoreComponent
{
    [SerializeField] 
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    public float maxShield;
    public float currentShieldHealth;

    //Create an Event which tracks when the Health reaches zero
    public event Action OnHealthZero;

    //Create an Event which tracks when the Shield reaches zero
    public event Action OnShieldZero;
    public event Action OnShieldFull;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
        currentShieldHealth = maxShield;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //Invoke the event.
            OnHealthZero?.Invoke();
            base.Log("Health is zero!");
        }
    }
    public void DecreaseShield(float amount)
    {
        currentShieldHealth -= amount;
        if (currentShieldHealth <= 0)
        {
            currentShieldHealth = 0;
            OnShieldZero?.Invoke();
            base.Log("Shield is zero");
        }
    }
    public void IncreaseHealth (float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
    public void IncreaseShield(float amount)
    {
        currentShieldHealth = Mathf.Clamp(currentShieldHealth + amount, 0, maxShield);
        if (currentShieldHealth == maxShield)
            OnShieldFull?.Invoke();
    }
    public float getHealth()
    {
        return currentHealth;
    }
}

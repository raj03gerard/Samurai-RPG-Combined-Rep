using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }
    private Stats Stats { get => stats ?? core.GetCoreComponent(ref stats); }
    private ParticleManager ParticleManager { get => particleManager ?? core.GetCoreComponent(ref particleManager); }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Stats stats;
    private ParticleManager particleManager;

    public bool isKnockbackActive;
    private float knockbackStartTime;

    [SerializeField] private float maxKnockbacktime = 0.2f;

    [SerializeField] private GameObject damageParticles;
    
    public override void LogicUpdate()
    {
        CheckKnockback();
    }
    public void Damage(float amount)
    {
        
        Stats?.DecreaseHealth(amount);
        Debug.Log(core.transform.parent.name + " Damaged By Amount: "+ amount);
       
        ParticleManager?.StartParticlesWithRandomRotation(damageParticles);
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        Movement?.SetVelocity(strength, angle, direction);
        Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
        Debug.Log("Knockback!");
    }

    private void CheckKnockback()
    {
        if (isKnockbackActive && ((Movement?.CurrentVelocity.y <= 0.01f && CollisionSenses.Ground) || Time.time >= knockbackStartTime + maxKnockbacktime))
        {
            isKnockbackActive = false;
            Movement.CanSetVelocity = true;
        }
    }
}

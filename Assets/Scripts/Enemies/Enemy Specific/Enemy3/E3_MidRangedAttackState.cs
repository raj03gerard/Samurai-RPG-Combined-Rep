using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MidRangedAttackState : RangedAttackState
{
    Enemy3 enemy;
    Enemy3.EnemyType enemyType;

    public E3_MidRangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Enemy3 enemy, Enemy3.EnemyType enemyType) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
        this.enemyType = enemyType;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isKnockbackActive)
        {

            stateMachine.ChangeState(enemy.stunState);
        }

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {

                int randInt = Random.Range(1, 3);
                if (randInt == 1)
                    stateMachine.ChangeState(enemy.chargeState);
                else
                {
                    stateMachine.ChangeState(enemy.playerDetectedState);
                }

            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        //base.TriggerAttack();
        if (enemyType == Enemy3.EnemyType.mikoshi_nyudo)

        { 
            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.midRangeAttackDamage, stateData.whatIsPlayer);

            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();
                IBlockable blockable = collider.GetComponent<IBlockable>();
                Shield shield = collider.GetComponent<Shield>();
                if (damageable != null)
                {
                    if (blockable != null)
                    {
                        if (shield.canBeDamagedNow)
                            damageable.Damage(stateData.midRangeAttackDamage);
                        else blockable.DamageShield(stateData.midRangeAttackDamage*2);
                    }
                    else
                    damageable.Damage(stateData.midRangeAttackDamage);
                }

                IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

                if (knockbackable != null)
                {
                    knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
                }
             }
        }
        else if (enemyType== Enemy3.EnemyType.o_kiku)
        {
            projectile = GameObject.Instantiate(stateData.projectile, enemy.midRangedAttackPosition.position, enemy.midRangedAttackPosition.rotation);
            projectile.GetComponent<AimedProjectile>().FireProjectile(movement.FacingDirection);
        }
    }

}

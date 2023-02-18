using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_LongRangedAttackState : RangedAttackState
{
    Enemy3 enemy;
    //public GameObject projectile;
    public E3_LongRangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        int rand_range_Attack_no = Random.Range(0, 10);

        entity.anim.SetInteger("ranged_attack_no", rand_range_Attack_no);
        
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
                   
                    stateMachine.ChangeState(enemy.angryIdleState);
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
        projectile = GameObject.Instantiate(stateData.projectile, enemy.rangedAttackPosition.position, enemy.rangedAttackPosition.rotation);
        projectile.GetComponent<AimedProjectile>().FireProjectile();
    }

}

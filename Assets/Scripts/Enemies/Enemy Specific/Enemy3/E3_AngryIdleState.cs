using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_AngryIdleState : PlayerDetectedState
{
    Enemy3 enemy;
    D_AngryIdleState angryIdleData;
    D_RangedAttackState RangedAttackData;
    public E3_AngryIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, D_AngryIdleState angryIdleData, D_RangedAttackState RangedAttackData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.angryIdleData = angryIdleData;
        this.RangedAttackData = RangedAttackData;
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isKnockbackActive)
        {
            Debug.Log("STUN While in AngryIdleState!!");
            stateMachine.ChangeState(enemy.stunState);
        }
        if (!isDetectingLedge)
        {
            Movement?.Flip();
            stateMachine.ChangeState(enemy.moveState);
        }
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);

        }
        if (!(Time.time>= startTime+angryIdleData.AngryIdleMaxDuration))
            return;
        
        
        else if (performLongRangeAction)
        {
            int randInt = Random.Range(1, 3);
             if (isInMidRangeAttackDistance())
            {
                if (randInt == 1)
                    stateMachine.ChangeState(enemy.chargeState);
                else if (enemy.enemyType== Enemy3.EnemyType.mikoshi_nyudo)
                {
                    stateMachine.ChangeState(enemy.midRangeAttackState);
                }
                else if (enemy.enemyType == Enemy3.EnemyType.o_kiku)
                {
                    stateMachine.ChangeState(enemy.midRangeAttackState_type_2);
                }
            }
            else if (isInLongRangeAttackDistance())
            {
                if (randInt == 1)
                    stateMachine.ChangeState(enemy.chargeState);
                else stateMachine.ChangeState(enemy.rangedAttackState);
            }
            
            else stateMachine.ChangeState(enemy.chargeState); ;

        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public bool isInLongRangeAttackDistance()
    {
        Transform playerCheck = enemy.GetPlayerCheckPosition();
        return Physics2D.Raycast(playerCheck.position, entity.transform.right, RangedAttackData.LongRangeAttackDistance, entity.entityData.whatIsPlayer);

    }
    public bool isInMidRangeAttackDistance()
    {
        Transform playerCheck = enemy.GetPlayerCheckPosition();
        return Physics2D.Raycast(playerCheck.position, entity.transform.right, RangedAttackData.MidRangeAttackDistance, entity.entityData.whatIsPlayer);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_ChargeState : ChargeState
{
    Enemy3 enemy;
    bool isPlayerInMaxAgroRange = false;
    D_RangedAttackState RangedAttackData;


    public E3_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, D_RangedAttackState RangedAttackData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.RangedAttackData = RangedAttackData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
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
        
        
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (isChargeTimeOver && isInMidRangeAttackDistance())
        {
            if (enemy.enemyType == Enemy3.EnemyType.mikoshi_nyudo)
                stateMachine.ChangeState(enemy.midRangeAttackState);
            else if (enemy.enemyType == Enemy3.EnemyType.o_kiku)
                stateMachine.ChangeState(enemy.midRangeAttackState_type_2);
        }
        else if ( isChargeTimeOver && isInLongRangeAttackDistance())
        {
            stateMachine.ChangeState(enemy.rangedAttackState);
        }
        
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                if (!enemy.hasDetectedPlayer)
                {
                    enemy.hasDetectedPlayer = true;
                    stateMachine.ChangeState(enemy.playerDetectedState);
                }
                else stateMachine.ChangeState(enemy.angryIdleState);
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

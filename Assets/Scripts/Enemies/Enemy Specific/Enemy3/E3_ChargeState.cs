using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_ChargeState : ChargeState
{
    Enemy3 enemy;
    D_RangedAttackState RangedAttackData;


    public E3_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, D_RangedAttackState RangedAttackData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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


        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (isChargeTimeOver && performMidRangeAction)
        {
            stateMachine.ChangeState(enemy.midRangeAttackState);
        }
        else if (isChargeTimeOver && performLongRangeAction)
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
                    stateMachine.ChangeState(enemy.enterAngryState);
                }
                else stateMachine.ChangeState(enemy.playerDetectedState);
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

}

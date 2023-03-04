using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_MoveState : MoveState
{
    private NPC1 enemy;


    bool isPlayerBehindEnemy;

    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;
    public NPC1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, NPC1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (enemy.CheckPlayerInCloseRangeAction() && enemy.hasInteractionEnded)
        {
            enemy.hasDetectedPlayer = true;
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

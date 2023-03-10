using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MoveState : MoveState
{
    private Enemy3 enemy;
    private Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
    private Combat combat;
    private bool isKnockbackActive;
    bool isPlayerBehindEnemy;

    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;
    public E3_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        isKnockbackActive = Combat.isKnockbackActive;

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isKnockbackActive)
        {

            isPlayerBehindEnemy = entity.CheckPlayerBehindEnemy();
            if (isPlayerBehindEnemy)
            {
                
                Debug.Log("Player behind enemy!");
            }
        }
        if (isPlayerInMinAgroRange)
        {
            enemy.hasDetectedPlayer = true;
            stateMachine.ChangeState(enemy.enterAngryState);    
        }
        else if (isDetectingWall || isDetectingBlockingWall || !isDetectingLedge)
        {
            if (isDetectingBlockingWall)
                Debug.Log("Blocking wall detected");
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

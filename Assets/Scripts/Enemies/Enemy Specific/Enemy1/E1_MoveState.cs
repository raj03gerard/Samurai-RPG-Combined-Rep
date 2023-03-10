using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private Enemy1 enemy;

    private Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
    private Combat combat;
    private bool isKnockbackActive;
    bool isPlayerBehindEnemy;

    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
                stateMachine.ChangeState(enemy.stunState);
                Debug.Log("Player behind enemy!");
            }
        }
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
          else if(isDetectingWall || isDetectingBlockingWall || !isDetectingLedge)
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

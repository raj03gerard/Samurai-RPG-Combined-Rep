using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MeleeAttackState : MeleeAttackState
{
    private Enemy3 enemy;
    public E3_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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
            Debug.Log("STUNNNNNNNNN!!");
            stateMachine.ChangeState(enemy.stunState);
        }

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {

                stateMachine.ChangeState(enemy.playerDetectedState);


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
        base.TriggerAttack();
    }
}

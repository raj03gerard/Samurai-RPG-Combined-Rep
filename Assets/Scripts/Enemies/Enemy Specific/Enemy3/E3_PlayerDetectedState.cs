using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_PlayerDetectedState : PlayerDetectedState
{
    Enemy3 enemy;
    D_RangedAttackState RangedAttackData;
    public E3_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, D_RangedAttackState RangedAttackData, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
        this.RangedAttackData = RangedAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        base.DoChecks();
        Movement?.SetVelocityX(0.0f);
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
            Debug.Log("STUN While in PlayerDetectedState!!");
            stateMachine.ChangeState(enemy.stunState);
        }
        if (isAnimationCompleted)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(enemy.meleeAttackState);

            }
            else if (performMidRangeAction)
            {
                int randInt = Random.Range(1, 3);
                if (randInt == 1)
                    stateMachine.ChangeState(enemy.chargeState);
                else stateMachine.ChangeState(enemy.midRangeAttackState);
            }

            else if (performLongRangeAction)
            {
                stateMachine.ChangeState(enemy.rangedAttackState);
            }


            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
            else if (!isDetectingLedge)
            {
                Movement?.Flip();
                stateMachine.ChangeState(enemy.moveState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    //public  void OnDrawGizoms()
    //{
    //    Transform playerCheck = enemy.GetPlayerCheckPosition();
    //    Gizmos.DrawLine(playerCheck.position, entity.transform.right.normalized * LongRangeAttackDistance);
    //}
}

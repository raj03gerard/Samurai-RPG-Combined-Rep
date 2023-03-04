using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_PlayerDetectedState : PlayerDetectedState
{
    NPC1 enemy;
    public NPC1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, NPC1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        Movement?.SetVelocityX(0.0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {

        base.LogicUpdate();
        Debug.Log("NPC Player detected state");



        if (enemy.CheckPlayerInMinAgroRange())

        {
            enemy.hasInteractionEnded = false;
            stateMachine.ChangeState(enemy.interactState);
        }

            
            
           else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.forgetPlayerState);
            }
            else if (!isDetectingLedge)
            {
                Movement?.Flip();
                stateMachine.ChangeState(enemy.moveState);
            }
        

    }

    public override void PhysicsUpdate()
    {
        
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

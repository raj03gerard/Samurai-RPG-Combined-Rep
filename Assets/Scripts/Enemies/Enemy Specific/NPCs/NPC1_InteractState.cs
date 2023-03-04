using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_InteractState : State
{
    NPC1 enemy;
    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    public delegate void OnMeetingPlayer(string dialog, GameObject interactingNPC, string VCam_Area);
    public static event OnMeetingPlayer DialogPrompt;
    NPC_InteractionData stateData;
    public NPC1_InteractState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, NPC_InteractionData stateData, NPC1 enemy) : base(entity, stateMachine, animBoolName)
    {
        this.enemy = enemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        Movement?.SetVelocityX(0.0f);
        if(DialogPrompt!=null)
        DialogPrompt(stateData.Dialog, enemy.gameObject, stateData.VCam_Area);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {

        base.LogicUpdate();

        
        if(enemy.hasInteractionEnded)
        {
           stateMachine.ChangeState( enemy.forgetPlayerState);
        }
        else if (!enemy.CheckPlayerInMinAgroRange() && !enemy.CheckPlayerInLongRangeAction() && !enemy.CheckPlayerInMidRangeAction())
        {
            stateMachine.ChangeState(enemy.forgetPlayerState);
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

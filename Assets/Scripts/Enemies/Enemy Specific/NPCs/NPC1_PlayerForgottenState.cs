using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_ForgetPlayerState : State
{
    NPC1 enemy;
    public delegate void OnForgettingPlayer(GameObject InteractingNPC);
    public static event OnForgettingPlayer RemoveDialogPrompt;
    public NPC1_ForgetPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, NPC1 enemy) : base(entity, stateMachine, animBoolName)
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
        if (RemoveDialogPrompt != null)
            RemoveDialogPrompt(enemy.gameObject);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        
            enemy.stateMachine.ChangeState(enemy.moveState);
        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}

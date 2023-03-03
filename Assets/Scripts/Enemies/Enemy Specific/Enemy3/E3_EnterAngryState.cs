using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_EnterAngryState : State
{
    Enemy3 enemy;
    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    protected bool isKnockbackActive;

    private Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
    private Combat combat;
    public E3_EnterAngryState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Enemy3 enemy) : base(entity, stateMachine, animBoolName)
    {
        this.enemy = enemy;

    }
    public override void DoChecks()
    {
        base.DoChecks();
        isKnockbackActive = Combat.isKnockbackActive;
    }
    public override void Enter()
    {
        base.Enter();

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
            Debug.Log("STUN While in EnterAngryState!!");
            stateMachine.ChangeState(enemy.stunState);
        }
        if (isAnimationCompleted)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);

        }
    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}

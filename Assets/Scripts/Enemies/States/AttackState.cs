using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    protected Movement movement;

    private Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
    private Combat combat;

    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isKnockbackActive;

    protected bool isPlayerInMinAgroRange;

    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isKnockbackActive = Combat.isKnockbackActive;
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;
        isAnimationFinished = false;
        Movement?.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        Movement?.SetVelocityX(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}

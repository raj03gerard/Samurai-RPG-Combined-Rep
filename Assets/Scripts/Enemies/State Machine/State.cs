using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected Core core;
    public float startTime { get; protected set; }

    protected string animBoolName;
    protected bool isAnimationCompleted;
    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        core = entity.core;
    }

    public virtual void Enter()
    {

        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        isAnimationCompleted = false;
        //Debug.Log(animBoolName);

        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
    public virtual void AnimationFinishTrigger()
    {
        isAnimationCompleted = true;
    }
}

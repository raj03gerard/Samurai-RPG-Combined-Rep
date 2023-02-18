using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_RetractNeckState : State
{
    Enemy3 enemy;
    public E3_RetractNeckState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Enemy3 enemy) : base(entity, stateMachine, animBoolName)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}

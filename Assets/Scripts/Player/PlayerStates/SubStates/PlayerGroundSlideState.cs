using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundSlideState : PlayerGroundedState
{
    GameObject particleContainer;
    public PlayerGroundSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        //Movement?.SetVelocityX(0f);
        particleContainer = GameObject.FindGameObjectWithTag("ParticleContainer");
        GameObject dashParticlesObj = GameObject.Instantiate(player.DashParticlesPrefab, player.DashEffectParticles.transform.position, player.DashEffectParticles.transform.rotation, particleContainer.transform);
        GameObject.Destroy(dashParticlesObj, 2f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(10f);
        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

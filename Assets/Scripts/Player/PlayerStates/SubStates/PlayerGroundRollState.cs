using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundRollState : PlayerGroundedState
{
    public PlayerGroundRollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerData.speedBoost = 5;

    }

    public override void Exit()
    {
        base.Exit();
        playerData.speedBoost = 1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(playerData.movementVelocity * playerData.speedBoost * xInput);
        //Movement?.SetVelocityX(0f); //Added for Stun State - check if it's necessary when improve respective code.

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

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        Debug.Log("Roll animation finished");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitBlockState : PlayerAbilityState
{
    public PlayerExitBlockState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void AnimationFinishTrigger()
    {
        stateMachine.ChangeState(player.IdleState);
    }
}

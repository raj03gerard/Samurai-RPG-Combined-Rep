using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : PlayerAbilityState
{
    float PlayerGravity;
    Rigidbody2D rb;
    RigidbodyConstraints2D OriginalConstraints;
    public PlayerBlockState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        this.player = player;
        rb = player.gameObject.GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        base.Enter();
        player.isBlocking = true;
        PlayerGravity = rb.gravityScale;
        rb.gravityScale = 0;
        OriginalConstraints = rb.constraints;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Movement?.SetVelocityX(0f); // Not Working!!
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            player.isBlocking = false;
            AnimationFinishTrigger();
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!player.canDeployShield)
            {
                player.isBlocking = false;
                AnimationFinishTrigger();
            }
        }
    }
    public override void Exit()
    {
        base.Exit();
        player.gameObject.GetComponent<Rigidbody2D>().gravityScale = PlayerGravity;
        rb.constraints = OriginalConstraints;
    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
        player.isBlocking = false;
        stateMachine.ChangeState(player.ExitBlockState);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class E1_TauntState : MeleeAttackState
//{
//    Enemy1 enemy;
//    int Random_No = 0;
//    public E1_TauntState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
//    {
//        this.enemy = enemy;
//    }

//    public override void Enter()
//    {
//        base.Enter();

//        core.Movement.SetVelocityX(0.0f);
//    }

//    public override void Exit()
//    {
//        base.Exit();
//    }

//    public override void LogicUpdate()
//    {
//        base.LogicUpdate();

//        if (isAnimationFinished)
//        {
//            if (isPlayerInMinAgroRange)
//            {
//                stateMachine.ChangeState(enemy.playerDetectedState);
//            }
//            else
//            {
//                stateMachine.ChangeState(enemy.lookForPlayerState);
//            }
//        }
//    }

//    public override void PhysicsUpdate()
//    {
//        base.PhysicsUpdate();
//    }
//}

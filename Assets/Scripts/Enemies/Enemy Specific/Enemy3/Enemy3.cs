using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
    public enum EnemyType { mikoshi_nyudo, o_kiku};
    public E3_IdleState idleState { get; private set; }
    public E3_MoveState moveState { get; private set; }
    public E3_PlayerDetectedState playerDetectedState { get; private set; }
    public E3_ChargeState chargeState { get; private set; }
    public E3_LookForPlayerState lookForPlayerState { get; private set; }
    public E3_MeleeAttackState meleeAttackState { get; private set; }

    public E3_StunState stunState { get; private set; }
    public E3_DeadState deadState { get; private set; }

    public E3_RetractNeckState retractNeckState { get; private set; }

    public E3_LongRangedAttackState rangedAttackState { get; private set; }

    public E3_AngryIdleState angryIdleState { get; private set; }

    public E3_MidRangeAttackState midRangeAttackState { get; private set; }
    public MidRangeAttackState_Type_2 midRangeAttackState_type_2 { get; private set; }

    public StunState stunState_2 { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackData;

    [SerializeField]
    private D_AngryIdleState angryIdleData;
    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    public Transform rangedAttackPosition;
    [SerializeField]
    public Transform midRangedAttackPosition;
    [SerializeField]
    public EnemyType enemyType;

    #region GameLogic Variables
    public bool hasDetectedPlayer = false;
    public bool hasBossFightStarted = false;
    #endregion
    public override void Awake()
    {
        base.Awake();

        moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E3_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E3_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData,rangedAttackData, this);
        chargeState = new E3_ChargeState(this, stateMachine, "charge", chargeStateData, rangedAttackData, this);
        lookForPlayerState = new E3_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
        meleeAttackState = new E3_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new E3_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E3_DeadState(this, stateMachine, "dead", deadStateData, this);
        retractNeckState = new E3_RetractNeckState(this, stateMachine, "playerForgotten", this);
        rangedAttackState = new E3_LongRangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackData, this);
        midRangeAttackState = new E3_MidRangeAttackState(this, stateMachine, "midRangedAttack", rangedAttackPosition, rangedAttackData, this);
        midRangeAttackState_type_2 = new MidRangeAttackState_Type_2(this, stateMachine, "midRangedAttack_type_2", rangedAttackPosition, rangedAttackData, this);
        angryIdleState = new E3_AngryIdleState(this, stateMachine, "angryIdle", playerDetectedData, angryIdleData, rangedAttackData, this);
    }

    private void Start()
    {

        stateMachine.Initialize(idleState);
        movement?.Flip();
    }

    //----------------Test Code-----------------------------------------------------
    public State GetCurrentState()
    {
        return stateMachine.currentState;
    }
    public void SetCurrentState(State newState)
    {
        stateMachine.Initialize(newState);
    }

    public Transform GetPlayerCheckPosition()
    {
        return playerCheck;
    }
    
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}

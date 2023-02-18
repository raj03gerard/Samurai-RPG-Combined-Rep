using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_MeleeAttack_2_State meleeAttack_2_State { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_DeadState deadState { get; private set; }
    //public E1_TauntState tauntState { get; private set; }

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
    private Transform meleeAttackPosition;
    State cur_state;
    public override void Awake()
    {
        base.Awake();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
        meleeAttackState = new E1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        meleeAttack_2_State = new E1_MeleeAttack_2_State(this, stateMachine, "meleeAttack2", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new E1_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E1_DeadState(this, stateMachine, "dead", deadStateData, this);
        //tauntState= new E1_TauntState(this, stateMachine, "taunt", meleeAttackPosition, meleeAttackStateData, this);

        //---------------test variable----------------
        //stunState_2 = new StunState(this, stateMachine, "stun", stunStateData, this);
       
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);
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

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player_Weapon"))
    //    {   
    //        cur_state= GetCurrentState();
    //        stateMachine.ChangeState(stunState);
    //        Debug.Log("Enemy hit by Player");
    //    }
    //}
    //public void Change_To_PlayerDetected_State()
    //{
    //    if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hurt") && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
    //    {
    //        this.GetComponent<Animator>().SetBool("stun", false);
    //        SetCurrentState(playerDetectedState);
    //        //stateMachine.ChangeState(playerDetectedState);
    //    }
    //}

    //----------------Test Code-----------------------------------------------------


    // We use Combat Core component instead.
    //public override void Damage(AttackDetails attackDetails)
    //{
    //    base.Damage(attackDetails);

    //    if (isDead)
    //    {
    //        stateMachine.ChangeState(deadState);
    //    }
    //    else if (isStunned && stateMachine.currentState != stunState)
    //    {
    //        stateMachine.ChangeState(stunState);
    //    }
    //    else if (!CheckPlayerInMinAgroRange())
    //    {
    //        lookForPlayerState.SetTurnImmediately(true);
    //        stateMachine.ChangeState(lookForPlayerState);
    //    }
    //}

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}

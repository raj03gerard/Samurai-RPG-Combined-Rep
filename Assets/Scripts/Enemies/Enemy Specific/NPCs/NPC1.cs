using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : Entity
{
    public NPC1_IdleState idleState { get; private set; }
    public NPC1_MoveState moveState { get; private set; }
    public NPC1_PlayerDetectedState playerDetectedState { get; private set; }

    public NPC1_InteractState interactState { get; private set; }
    public NPC1_ForgetPlayerState forgetPlayerState { get; private set; }


    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedData;
    [SerializeField]
    private NPC_InteractionData NPCInteractionData;
    
    State cur_state;

    #region GameLogic Variables
    public bool hasDetectedPlayer = false;
    public bool hasInteractionStarted = false;
    public bool hasInteractionEnded = true;
    
    #endregion
    public override void Awake()
    {
        base.Awake();

        moveState = new NPC1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new NPC1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new NPC1_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        interactState = new NPC1_InteractState(this, stateMachine, "interact", NPCInteractionData, this);
        forgetPlayerState = new NPC1_ForgetPlayerState(this, stateMachine, "playerForgotten", this);
        
    }

    private void Start()
    {
        hasInteractionEnded = true;
        stateMachine.Initialize(idleState);
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

        
    }
    public void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }
    public void SetHasInteractionEndedTrue()
    {
        StartCoroutine(WaitBeforeInteractingAgain());
    }
    IEnumerator WaitBeforeInteractingAgain()
    {
        yield return new WaitForSeconds(3f);
        hasInteractionEnded = true;
    }

}

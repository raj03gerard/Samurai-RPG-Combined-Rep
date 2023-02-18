using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStatemachine : MonoBehaviour
{
    public AttackState attackState;
    public Animator anim;
    //public StunState stunState;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    public void EnterHurtState()
    {
        //stunState.LogicUpdate();
    }
    public void ExitPlayerDetectedState()
    {
        anim.SetBool("playerDetected", false);
    }
   public void ExitPlayerForgottenState()
    {
        anim.SetBool("playerForgotten", false);
        
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class E1_Combat : Combat
//{
//    public new bool isKnockbackActive;
//    private float knockbackStartTime;

//    [SerializeField]
//    private float maxKnockbacktime = 0.2f;
//    State cur_state;

//    public override void LogicUpdate()
//    {
//        base.LogicUpdate();
//        CheckKnockback();
//    }
   

//    public override void Knockback(Vector2 angle, float strength, int direction)
//    {
//        core.Movement.SetVelocity(strength, angle, direction);
//        core.Movement.CanSetVelocity = false;
//        isKnockbackActive = true;
//        //---------------------
//        cur_state = core.transform.parent.GetComponent<Enemy1>().GetCurrentState();
//        Animator anim = core.transform.parent.GetComponent<Animator>();
//        anim.SetBool("stun", true);
//        //---------------------
//        knockbackStartTime = Time.time;


//    }

//    public override void CheckKnockback()
//    {
//        if (isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && (core.CollisionSenses.Ground || Time.time >= knockbackStartTime + maxKnockbacktime))
//        {
//            isKnockbackActive = false;
//            //-----------------------
//            Animator anim = core.transform.parent.GetComponent<Animator>();
//            anim.SetBool("stun", false);
//            core.transform.parent.GetComponent<Enemy1>().SetCurrentState(cur_state);
//            //-----------------------
//            core.Movement.CanSetVelocity = true;
//        }
//    }
//    //-----------Test Fcn---------------
//    //public void GetHurt()
//    //{
//    //    AnimationToStatemachine atsm_obj = core.transform.parent.GetComponent<AnimationToStatemachine>();
//    //    atsm_obj.EnterHurtState();
//    //}
//}

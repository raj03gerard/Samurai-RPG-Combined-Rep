using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimStatesControls : MonoBehaviour
{
    protected PlayerGroundSlideState state;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Slide/Roll Animations
    private void SlideRollEntered()
    {
        Player.canAttack = false;
        Player.canJump = false;

    }
    private void SlideRollExit()
    {
        Player.canAttack = true;
        Player.canJump = true;
        this.GetComponent<Animator>().SetBool("slide", false);
        this.GetComponent<Animator>().SetBool("roll", false);

    }
    #endregion
}
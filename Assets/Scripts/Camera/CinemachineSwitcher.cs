using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool BaseCamera = true;

    
    void Awake()
    {
        anim = GameObject.Find("CM StateDrivenCamera1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwitchState()
    {
        if (BaseCamera)
        {
            anim.Play("SpiderNest");
        }
        else anim.Play("BaseLevel");

        BaseCamera = !BaseCamera;
    }
    void SwitchToThisVCam()
    {
        anim.Play(this.gameObject.name);
    }
    void SwitchToCollidedVCam()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Call switchstate after colliding with " + collision.gameObject.name);
            //SwitchState();
            SwitchToThisVCam();
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log("Call switchstate after colliding with " + collision.gameObject.name);
    //        SwitchState();
    //    }
    //}
}

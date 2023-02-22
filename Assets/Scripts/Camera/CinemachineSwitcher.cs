using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool BaseCamera = true;

    [SerializeField]
    GameObject Mikoshi_Nyudo_Cinematic_Holder;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Main_Body;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Spwan_Point;
    [SerializeField]
    GameObject Mikoshi_Nyudo_VCam;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Call switchstate after colliding with " + collision.gameObject.name);
            SwitchState();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Call switchstate after colliding with " + collision.gameObject.name);
            SwitchState();
        }
    }
}

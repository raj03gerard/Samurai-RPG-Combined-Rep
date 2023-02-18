using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitchBaseToShunga : MonoBehaviour
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
            anim.Play("ShungaTakoArea");
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
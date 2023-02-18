using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGIColor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float disp_time_val = 0f;
    public static float time_val = 0f;
    public float moveSpeed = 0f;
    float moveDir;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        disp_time_val = time_val;
        moveDir = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision");
        disp_time_val = 0.2f;
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "village1")
    //    {
    //        disp_time_val = 0.5f;
    //        time_val = 0.5f;
    //    }
    //}
}

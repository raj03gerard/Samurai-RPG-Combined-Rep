using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdraftHandler : MonoBehaviour
{
    [SerializeField]
    private float UpdraftForce = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Updraft hit " + collision.gameObject.name);
        if(collision.gameObject.name=="Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, UpdraftForce));
        }
    }
}

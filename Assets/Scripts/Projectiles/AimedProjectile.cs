using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    private float speed=50f;
    private float travelDistance;
    private float xStartPos;
    public float damage = 20;

    private Rigidbody2D rb;
    public Vector3 targetPosition;
    public Vector3 direction;
    public bool isProjectileFired = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isProjectileFired)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void FireProjectile()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        isProjectileFired = true;
        Destroy(this.gameObject, 1f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameObject.name + " has hit " + collision.gameObject.name);
    }

}

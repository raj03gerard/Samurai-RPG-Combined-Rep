using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    private float speed = 50f;
    private float travelDistance;
    private float xStartPos;
    public float damage = 20;

    private Rigidbody2D rb;
    public Vector3 targetPosition;
    public Vector3 direction;
    public bool isProjectileFired = false;
    bool isGravityOn = false;
    int FacingDirection = 1;

    public GameObject HitSplash;
    [SerializeField]
    GameObject damagePosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isProjectileFired)
        {
            //transform.position = Vector3.MoveTowards(transform.position, transform.right* -FacingDirection*100, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,  new Vector3(FacingDirection* targetPosition.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            rb.gravityScale = 0;
            if (!isGravityOn)
                StartCoroutine(StartDipping());
            else
            { if (FacingDirection > 0)
                {
                    transform.Rotate(transform.forward.normalized * -10f * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(transform.forward.normalized * 10f * Time.deltaTime);
                }
             }
        }
    }
    IEnumerator StartDipping()
    {
        yield return new WaitForSeconds(0.4f);
        isGravityOn = true;
        rb.gravityScale = 5;
    }
    public void FireProjectile(int facingDirection)
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        targetPosition = new Vector3(targetPosition.x * 100, this.transform.position.y, this.transform.position.z);
        isProjectileFired = true;
        this.FacingDirection = facingDirection;
        Debug.Log("Projectile firedd");
        Destroy(this.gameObject, 1f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameObject.name + " has hit " + collision.gameObject.name);
        if (collision.gameObject.name==("Combat"))
        {
            Combat combat = collision.gameObject.GetComponent<Combat>();
            Shield shield = collision.gameObject.GetComponent<Shield>();
            if (shield == null || !shield.canBeDamagedNow)
            {
                shield.DamageShield(10f);
            }
            else 
            {
                Debug.Log("shield= " + shield + shield.canBeDamagedNow);
                combat.Damage(5f);
                Instantiate(HitSplash, damagePosition.transform.position, damagePosition.transform.rotation);
            }

            
            Destroy(this.gameObject);  
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(HitSplash, damagePosition.transform.position, damagePosition.transform.rotation);
            Destroy(this.gameObject);
        }
    }

}

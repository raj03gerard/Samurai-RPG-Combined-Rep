using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    [SerializeField]
    public float speed = 5f;
    public DayNightCycleController dnController;
    public bool changeColorVillage1 = false;
    public bool changeColorRain1 = false;
    float lerp1 = 0f;
    float lerp2 = 0f;
    public GameObject rainController1;
    public ParticleSystem rain1end1;
    public ParticleSystem rain1end2;


    void Start()
    {
        rainController1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(changeColorVillage1)
        {
            lerp1 += Time.deltaTime / 5f;
            dnController.time = Mathf.Lerp(0.3f, 0.5f, lerp1);
        }
        else if(changeColorRain1)
        {
            lerp2 += Time.deltaTime / 3f;
            dnController.time = Mathf.Lerp(0.1f, 0.3f, lerp2);
        }
    }

    void Movement()
    {
        float moveX = 0;

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX -= 1f;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX += 1;
        }

        Vector3 moveDir = new Vector3(moveX, 0).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("village1"))
        {
            changeColorVillage1 = true;
        }
        else if(other.gameObject.CompareTag("rain1start"))
        {
            changeColorRain1 = true;
            rainController1.SetActive(true);
        }
        else if(other.gameObject.CompareTag("rain1end"))
        {
            rain1end1.loop = false;
            rain1end2.loop = false;
            Destroy(rainController1, 5f);
        }
    }
    */
}

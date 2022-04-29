using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class FireBulletScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float destroyTimer = 3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 velocity = rb.velocity;

        destroyTimer -= Time.deltaTime;

    

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }




    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }




}

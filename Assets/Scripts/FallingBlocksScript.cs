using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float setfallTimer;
    public float fallTimer;
    public float respawnTimer = 5f;
    public bool playerInteract;
    public bool respawn;
    public float xPosition;
    public float yPoisiton;

    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        fallTimer = setfallTimer;
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;

        if (playerInteract == true)
        {
            fallTimer -= Time.deltaTime;
        }

        if (respawn == true)
        {
            respawnTimer -= Time.deltaTime;
        }

        if (fallTimer <= 0.5)
        {
            rb.gravityScale = 1;

            if (fallTimer <= 0)
            {
                transform.position = new Vector3(-50, -15, 0);
                playerInteract = false;
                fallTimer = setfallTimer;
                rb.gravityScale = 0;
                Helper.SetVelocity(0, 0, gameObject);
                respawn = true;
            }
        }

        if (respawnTimer <= 0)
        {
            
            transform.position = new Vector3(xPosition, yPoisiton, 0f);
            respawn = false;
            respawnTimer = 5f;
        }
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInteract = true;
        }
    }
}

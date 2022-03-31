using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public int health = 5;
    public float attackCooldown;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
     
        DoJump();
        DoMove();
        DoAttack();

        

    }

    void DoJump()
    {

        bool result = Helper.DoRayCollisionCheck(gameObject);
        Vector2 velocity = rb.velocity;

        if (Input.GetKey("w") && (result == true))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 10f;

            }

        }

        if (result == false && velocity.y > 0.01f)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if (velocity.y < -0.01)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }

        Helper.SetVelocity(velocity.x, velocity.y, gameObject);

    }

    void DoMove()
    {
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("a"))
        {
            velocity.x = -7;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            velocity.x = 7;
        }

        if (velocity.x > 0 || velocity.x < 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }


        Helper.SetVelocity(velocity.x, velocity.y, gameObject);

        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, Left);
        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Right);
        }
    }

    void DoAttack()
    {
        bool result = Helper.DoRayCollisionCheck(gameObject);

        attackCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && result == true && attackCooldown < 0)
        {
            anim.SetBool("Attack", true);
            attackCooldown = 0.65f;
        }
       
    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
    }


}

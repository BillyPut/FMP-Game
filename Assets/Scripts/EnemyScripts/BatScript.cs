using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class BatScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box;
    public int health = 1;
    public float attackCooldown;
    public float invulnerability;
    public GameObject enemyHitBox;
    public GameObject enemyHurtBox;
    public GameObject player;
    public bool attacking;
    public bool dead = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {



        FollowPlayer();



        if (health == 0)
        {
            anim.SetBool("Death", true);
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BatAttack"))
        {
            attacking = true;

        }
        else
        {

            enemyHitBox.SetActive(false);
            attacking = false;

        }



        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BatDeath"))
        {
            enemyHurtBox.SetActive(false);
            attacking = false;
            
            anim.SetBool("Attack", false);
            anim.SetBool("Flight", false);
            Helper.SetVelocity(0f, -5f, gameObject);
            
            dead = true;

        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BatSplat"))
        {
            Helper.SetVelocity(0f, 0f, gameObject);
        }



    }

    void FollowPlayer()
    {

        float ex = transform.position.x;
        float px = player.transform.position.x;
        float ey = transform.position.y;
        float py = player.transform.position.y;

        float distx = ex - px;
        float disty = ey - py - 0.4f;

        attackCooldown -= Time.deltaTime;

        Vector2 velocity = rb.velocity;


        velocity.x = 0;



        if (distx < 15 && distx > 0 && disty < 5 && disty > -5)
        {
            velocity.x = -1.6f;

            if (disty > 0.5)
            {
                velocity.y = -2;
            }
            if (disty < -0.5)
            {
                velocity.y = 2;
            }
            if (disty > -0.5 && disty < 0.5)
            {
                velocity.y = 0;
            }



        }
        if (distx > -15 && distx < 0 && disty < 5 && disty > -5)
        {
            velocity.x = 1.6f;

            if (disty > 0.5)
            {
                velocity.y = -2;
            }
            if (disty < -0.5)
            {
                velocity.y = 2;
            }
            if (disty > -0.5 && disty < 0.5)
            {
                velocity.y = 0;
            }

        }
        if (distx < 2.5 && distx > 0 && disty < 3 && disty > -1)
        {
            velocity.x = 0;

            if (attackCooldown < 0)
            {

                attacking = true;
                Helper.FlipSprite(gameObject, Left);
                anim.SetBool("Attack", true);
                attackCooldown = 1f;
            }


        }
        if (distx < 0 && distx > -2.5 && disty < 3 && disty > -1)
        {

            velocity.x = 0;

            if (attackCooldown < 0)
            {

                attacking = true;
                Helper.FlipSprite(gameObject, Right);
                anim.SetBool("Attack", true);
                attackCooldown = 1f;
            }

        }

        if (attacking == true)
        {
            velocity.x = 0;
            velocity.y = 0;

        }






        if (velocity.x > 0 || velocity.y > 0 || velocity.y < 0 || velocity.x < 0)
        {
            anim.SetBool("Flight", true);
        }
        else
        {
            anim.SetBool("Flight", false);
        }


        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, Left);



        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Right);


        }







        Helper.SetVelocity(velocity.x, velocity.y, gameObject);



    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        enemyHitBox.SetActive(false);
    }

  

    void ActivateHitbox()
    {
        enemyHitBox.SetActive(true);
    }

    void KillBat()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "PlayerAttackBox")
        {
            health = health - 1;






            anim.SetBool("Death", true);


        }


    }

    void OnCollisionEnter2D(Collision2D block)
    {

        

        if (block.gameObject.tag == "Platform")
        {
            if (dead == true)
            {
                anim.SetBool("Splat", true);
            }
           
        }
    }


}


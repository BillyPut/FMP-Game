using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public int health = 5;
    public int collectibles = 0;
    public float attackCooldown;
    public float dashCooldown;
    public float invulnerability;
    public bool attacking = false;
    public GameObject hitBox;
    public bool damaged;
    public bool dash = false;
    public bool dashing = false;
    public bool facingLeft = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        invulnerability -= Time.deltaTime;
     
        if (health == 0)
        {
            anim.SetBool("Death", true);
        }

        DoJump();
        DoMove();
        DoAttack();

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerKnightAttack"))
        {
            attacking = true;
            
        }
        else
        {
            attacking = false;
            hitBox.SetActive(false);
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerKnightHit"))
        {
            damaged = true;
            attacking = false;
            hitBox.SetActive(false);
            anim.SetBool("Attack", false);
        }
        else
        {
            damaged = false;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerKnightDeath"))
        {
            Helper.SetVelocity(0f, 0f, gameObject);
            
        }
    }

    void DoJump()
    {

        bool result = Helper.DoRayCollisionCheck(gameObject);
        Vector2 velocity = rb.velocity;

        if (Input.GetKey("w") && (result == true))
        {
            if (velocity.y < 0.01f)
            {
                anim.SetBool("Attack", false);
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

       
       
        if (dashing == false)
        {
            velocity.x = 0;
        }
        

        dashCooldown -= Time.deltaTime;
        
        
        if (dashing == false)
        {
            if (Input.GetKey("a"))
            {
                velocity.x = -6.5f;
            }
            if (Input.GetKey("a") && attacking == true)
            {
                velocity.x = -3.5f;
            }



            if (Input.GetKey("d"))
            {
                velocity.x = 6.5f;
            }
            if (Input.GetKey("d") && attacking == true)
            {
                velocity.x = 3.5f;
            }

        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && dash == true && dashCooldown <= 0)
        {
            dashing = true;
            dashCooldown = 3f;

        }

        if (dashCooldown <= 2.85f)
        {
            dashing = false;
        }
        if (facingLeft == true && dashCooldown > 2.85f)
        {
            velocity.x = -25f;
            velocity.y = 0;
        }
        if (facingLeft == false && dashCooldown > 2.85f)
        {
            velocity.x = 25f;
            velocity.y = 0;
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
            facingLeft = true;

     
        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Right);
            facingLeft = false;
 
        }
    }

    void DoAttack()
    {
        bool result = Helper.DoRayCollisionCheck(gameObject);

        attackCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && result == true && attackCooldown <= 0)
        {
           
            anim.SetBool("Attack", true);
            attackCooldown = 0.7f;
        }
       

    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
    }

    void EndHit()
    {
        anim.SetBool("Hit", false);
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }
    void ActivateHitbox()
    {
        hitBox.SetActive(true);
    }

    public void UnlockDash()
    {
        dash = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.gameObject.tag == "EnemyAttackBox" && invulnerability <= 0)
        {
            health = health - 1;


            invulnerability = 2;


            Helper.SetVelocity(20f, 2.5f, gameObject);
            anim.SetBool("Hit", true);


        }

        if (other.gameObject.tag == "Enemy" && invulnerability <= 0)
        {
            health = health - 1;


            invulnerability = 2;


            Helper.SetVelocity(20f, 2.5f, gameObject);
            anim.SetBool("Hit", true);
        }

        if (other.gameObject.tag == "RespawnBarrier")
        {
            health = health - 1;

            invulnerability = 2;

            anim.SetBool("Hit", true);

        }

        if (other.gameObject.tag == "Collectibles")
        {
            collectibles += 1;
        }

       

    }






}

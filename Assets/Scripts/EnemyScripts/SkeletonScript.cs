using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class SkeletonScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box;
    public int health = 3;
    public float attackCooldown;
    public float invulnerability;
    public GameObject enemyHitBox;
    public GameObject enemyHurtBox;
    public GameObject player;
    public bool attacking;


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

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAttack"))
        {
            attacking = true;

        }
        else
        {
            
            enemyHitBox.SetActive(false);
            attacking = false;

        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonHit"))
        {
            attacking = false;
            anim.SetBool("Attack", false);

            invulnerability = 0.5f;
            attackCooldown = 1f;

        }


        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonDeath"))
        {
            enemyHurtBox.SetActive(false);
            attacking = false;
            box.enabled = false;
            anim.SetBool("Attack", false);
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
        float disty = ey - py;

        attackCooldown -= Time.deltaTime;

        Vector2 velocity = rb.velocity;

        velocity.x = 0;

        if (distx < 15 && distx > 0 && disty < 3.5 && disty > -2.5)
        {
            velocity.x = -2;
            

        }
        if (distx > -15 && distx < 0 && disty < 3.5 && disty > -2.5)
        {
            velocity.x = 2;

        }
        if (distx < 3.5 && distx > 0 && disty < 3.5 && disty > -2.5)
        {
            velocity.x = 0;

            if (attackCooldown < 0)
            {
                attacking = true;
                Helper.FlipSprite(gameObject, Right);
                anim.SetBool("Attack", true);
                attackCooldown = 2.5f;
            }


        }
        if (distx < 0 && distx > -3.5 && disty < 3.5 && disty > -2.5)
        {

            velocity.x = 0;

            if (attackCooldown < 0)
            {
                attacking = true;
                Helper.FlipSprite(gameObject, Left);
                anim.SetBool("Attack", true);
                attackCooldown = 2.5f;
            }

        }
        if (attacking == true)
        {
            velocity.x = 0;
            
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonHit"))
        {
            
            velocity.x = 0;
            

        }


        if (velocity.x > 0 || velocity.x < 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, Right);

        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Left);

        }



        Helper.SetVelocity(velocity.x, velocity.y, gameObject);



    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        enemyHitBox.SetActive(false);
    }

    void EndHit()
    {
        anim.SetBool("Hit", false);
    }

    void ActivateHitbox()
    {
        enemyHitBox.SetActive(true);
    }

    void KillSkeleton()
    {
        Destroy(gameObject);
    }
       

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "PlayerAttackBox")
        {
            health = health - 1;


           


            
            anim.SetBool("Hit", true);


        }

    }



}

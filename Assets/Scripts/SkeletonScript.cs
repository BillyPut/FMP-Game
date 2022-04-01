using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class SkeletonScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public int health = 3;
    public float attackCooldown;
    public GameObject enemyHitBox;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        FollowPlayer();

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAttack"))
        {
            

        }
        else
        {
           
            enemyHitBox.SetActive(false);
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


        if (distx < 15 && distx > 0 && disty < 2 && disty > -2)
        {
            velocity.x = -2;
            

        }
        if (distx > -15 && distx < 0 && disty < 2 && disty > -2)
        {
            velocity.x = 2;

        }
        if (distx < 3 && distx > -3 && distx > 0 && disty < 2 && disty > -2 && attackCooldown < 0)
        {
            velocity.x = 0;
            anim.SetBool("Attack", true);
            attackCooldown = 1.5f;


        }
        else
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

    void ActivateHitbox()
    {
        enemyHitBox.SetActive(true);
    }



}

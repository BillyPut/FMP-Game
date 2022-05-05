using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class FinalBossScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box;
    public int health = 10;
    public GameObject enemyHitBox;
    public GameObject enemyHurtBox;
    public GameObject spellAttack;
    public GameObject player;
    public bool cast;
    public bool attack;
    public bool endCast;
    public bool newAttack;
    public int actionChoice;
    



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
        UseSpell();


        if (newAttack == true)
        {
            if (actionChoice >= 7)
            {
                attack = true;
                transform.position = new Vector3(Random.Range(-104.92f, -120.68f), 116f, 0f);
            }
            else
            {
                cast = true;
                transform.position = new Vector3(Random.Range(-106.51f, -118.77f), Random.Range(119.35f, 121.32f), 0f);
            }

            newAttack = false;
        }
       



        if (health == 0)
        {
            anim.SetBool("Hurt", true);
        }
    }


    public void AttackPlayer()
    {
        float ex = transform.position.x;
        float px = player.transform.position.x;

        float distx = ex - px;

        Vector2 velocity = rb.velocity;


        if (attack == true)
        {
            if (distx > 3.5)
            {
                velocity.x = -3;
            }
            if (distx < -3.5)
            {
                velocity.x = 3;
            }
            if (distx <= 3.5 && distx > 0)
            {
                
                anim.SetBool("Attack", true);
                
            }
            if (distx >= -3.5 && distx < 0)
            {
                
                anim.SetBool("Attack", true);
            }


            if (velocity.x > 0 || velocity.x < 0)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }




            if (velocity.x > 0.5)
            {
                Helper.FlipSprite(gameObject, Right);
            }
            if (velocity.x < -0.5)
            {
                Helper.FlipSprite(gameObject, Left);
            }


            Helper.SetVelocity(velocity.x, velocity.y, gameObject);

        }

      

    }


    public void UseSpell()
    {
        if (cast == true)
        {
            anim.SetBool("Cast", true);
            spellAttack.SetActive(true);

            if (endCast == true)
            {
                anim.SetBool("Teleport", true);
                cast = false;
            }
        }

    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        enemyHitBox.SetActive(false);
        attack = false;
        anim.SetBool("Teleport", true);

    }

    

    void EndTeleport()
    {
        anim.SetBool("Teleport", false);
        newAttack = true;
        actionChoice = Random.Range(0, 10);
        anim.SetBool("Reappear", true);
    }

    
    void ActivateHitbox()
    {
        enemyHitBox.SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttackBox")
        {
            health = health - 1;
            anim.SetBool("Teleport", true);
        }

    }
}

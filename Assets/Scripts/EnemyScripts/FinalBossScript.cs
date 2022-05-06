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
    public SpellAttackScript beginCast;
    public EndOfGameTransfer endGame;
    public GameObject player;
    public GameObject bossFloater;
    public bool cast;
    public bool attack;
    public bool attacking;
    public bool endCast;
    public bool stopCast;
    public bool newAttack;
    public bool startTimer;
    public int actionChoice;
    public float attackCooldown = 1.2f;
    public float invulnerability = 0.5f;
    public float deathCountdown = 0.9f;
    



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


        if (health == 0)
        {
            anim.SetBool("Teleport", true);
            deathCountdown -= Time.deltaTime;

            if (deathCountdown <= 0)
            {
                endGame.startTransfer = true;
                gameObject.SetActive(false);
                
            }
        }



        AttackPlayer();
        UseSpell();


        invulnerability -= Time.deltaTime;


        if (startTimer == true)
        {
            attackCooldown -= Time.deltaTime;
        }
    
        if (attackCooldown <= 0)
        {
            anim.SetBool("Teleport", true);
            startTimer = false;
            attackCooldown = 1.2f;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            enemyHurtBox.SetActive(false);
            box.enabled = false;
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Hurt", false);
            Helper.SetVelocity(0f, 0f, gameObject);
            

        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("FinalBossReappear"))
        {
            enemyHurtBox.SetActive(false);
            box.enabled = false;
            anim.SetBool("Attack", false);
            anim.SetBool("Teleport", false);
            anim.SetBool("Walk", false);
           
        }
     

        if (newAttack == true)
        {
            anim.SetBool("Reappear", false);
            enemyHurtBox.SetActive(true);
            box.enabled = true;
            cast = false;
            attack = false;
            endCast = false;
            stopCast = false;


            if (actionChoice < 7)
            {
                attack = true;
            }
            else
            {
                cast = true;
            }

            newAttack = false;
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

            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                velocity.x = 0f;
                anim.SetBool("Walk", false);
                attacking = true;
            }
            else
            {
                attacking = false;
            }

            if (distx > 3.5 && attacking == false)
            {
                velocity.x = -2.5f;
            }
            if (distx < -3.5 && attacking == false)
            {
                velocity.x = 2.5f;
            }
            if (distx <= 3.5 && distx > 0)
            {
                velocity.x = 0f;
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
                
            }
            if (distx >= -3.5 && distx < 0)
            {
                velocity.x = 0f;
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
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
                Helper.FlipSprite(gameObject, Left);
            }
            if (velocity.x < -0.5)
            {
                Helper.FlipSprite(gameObject, Right);
            }


            Helper.SetVelocity(velocity.x, velocity.y, gameObject);

        }

      

    }


    public void UseSpell()
    {

        if (cast == true)
        {
            bossFloater.SetActive(true);

            anim.SetBool("Walk", false);

            if (stopCast == true)
            {
                anim.SetBool("Cast", false);
            }
            else
            {
                anim.SetBool("Cast", true);
            }

            if (beginCast.attackTimer > 1.5f)
            {
                beginCast.startCast = true;
            }
            else
            {
                beginCast.startCast = false;
            }

            if (endCast == true)
            {
                anim.SetBool("Cast", false);
                anim.SetBool("Teleport", true);
                bossFloater.SetActive(false);
                cast = false;
            }
           
        }

    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        enemyHitBox.SetActive(false);
        attack = false;
        startTimer = true;
        

    }

    

    void EndTeleport()
    {
        anim.SetBool("Teleport", false);
        actionChoice = Random.Range(1, 10);
        if (actionChoice < 7)
        {
            transform.position = new Vector3(Random.Range(-106.5f, -116f), 116f, 0f);
        }
        else
        {
            transform.position = new Vector3(Random.Range(-106.5f, -116f), Random.Range(119.5f, 121f), 0f);
        }
        anim.SetBool("Reappear", true);
    }


    void EndCast()
    {
        anim.SetBool("Cast", false);
        stopCast = true;    
    }

    void EndReappear()
    {
        newAttack = true;
    }
    
    void EndHurt()
    {
        cast = false;
        attack = false;
        endCast = false;
        stopCast = false;
        startTimer = false;
        bossFloater.SetActive(false);
        attackCooldown = 1.2f;
        anim.SetBool("Hurt", false);
        anim.SetBool("Teleport", true);
    }
    
    void ActivateHitbox()
    {
        enemyHitBox.SetActive(true);
    }

    void DisableHitbox()
    {
        enemyHitBox.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttackBox" && invulnerability <= 0)
        {
            invulnerability = 0.5f;
            health -= 1;
            anim.SetBool("Hurt", true);

            if (cast == true)
            {
                beginCast.startCast = false;
                beginCast.finishCast = true;
                beginCast.transform.position = new Vector3(-130, 116, 0);
                beginCast.attackTimer = 2.5f;
            }
            
        }

    }
}

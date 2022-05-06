using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttackScript : MonoBehaviour
{
    private Animator anim;
    public GameObject player;
    public FinalBossScript casting;
    public GameObject spellHitbox;
    public bool finishCast;
    public bool startCast;
    public float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackTimer = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (casting.cast == true)
        {
            if (startCast == true)
            {
                transform.position = player.transform.position + new Vector3(0, 2, 0);
                attackTimer -= Time.deltaTime;
            }
            else
            {
                transform.position = transform.position;
            }



            if (attackTimer <= 1.5)
            {
                anim.SetBool("Shoot", true);
                startCast = false;
            }


            if (finishCast == true)
            {
                anim.SetBool("Shoot", false);
                spellHitbox.SetActive(false);
                casting.endCast = true;
                finishCast = false;
            }


            if (casting.endCast == true)
            {
                attackTimer = 2.5f;
                transform.position = new Vector3(-130, 116, 0);
            }
        }

       

    }

    public void ActivateHitbox()
    {
        spellHitbox.SetActive(true);
    }

    public void EndAttack()
    {
        spellHitbox.SetActive(false);
        finishCast = true;

    }


}

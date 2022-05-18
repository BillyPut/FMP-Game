using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallScript : MonoBehaviour
{
    private Animator anim;
    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    void EndHit()
    {
        anim.SetBool("WallHit", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "PlayerAttackBox")
        {
            health = health - 1;
            anim.SetBool("WallHit", true);


        }

    }
}

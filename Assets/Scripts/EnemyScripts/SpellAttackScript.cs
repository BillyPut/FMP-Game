using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttackScript : MonoBehaviour
{
    public GameObject player;
    public FinalBossScript endCast;
    public GameObject spellHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, 0);
    }

    public void ActivateHitbox()
    {
        spellHitbox.SetActive(true);
    }

    public void EndAttack()
    {
        spellHitbox.SetActive(false);

    }


}

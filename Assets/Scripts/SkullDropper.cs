using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDropper : MonoBehaviour
{
    public float dropTimer;
    public float originalDropTime;
    public float dropGap;
    public GameObject skullPrefab;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ex = transform.position.x;
        float px = player.transform.position.x;
       

        float distx = ex - px;


        

        if (distx < 15 && distx > -15)
        {

            dropTimer -= Time.deltaTime;

            if (dropTimer <= 0)
            {
                Helper.MakeBullet(skullPrefab, transform.position.x, transform.position.y - 0.5f, 0, 0);
                dropTimer = dropGap;
            }

            

        }
        else
        {
            dropTimer = originalDropTime;
        }
        
            
        
    }
}

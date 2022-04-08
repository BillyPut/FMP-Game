using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopIntro : MonoBehaviour
{
    public GameObject player;
    public GameObject introText;
    public GameObject buyText;
    
    public bool shopped = false;
    public bool shopping = false;
    public float readTimer = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ex = transform.position.x;
        float px = player.transform.position.x;
        float ey = transform.position.y;
        float py = player.transform.position.y;

        
        float disty = ey - py;
        float distx = ex - px;

        if (shopping == false && shopped == false)
        {
            if (Input.GetKeyDown("e") && distx < 3 && distx > -3 && disty < 2)
            {
                introText.SetActive(true);
                shopping = true;
                
            }

        }

        if (shopping == true)
        {
            readTimer -= Time.deltaTime;
        }

        if (shopping == true && Input.GetKeyDown("e") && readTimer < 0)
        {
            buyText.SetActive(true);
            introText.SetActive(false);


        }

       
    }


    public void BoughtAbility()
    {
        buyText.SetActive(false);
        shopped = true;
        shopping = false;
        readTimer = 0.5f;
    }

    public void NotBoughtAbility()
    {
        buyText.SetActive(false);
        shopping = false;
        readTimer = 0.5f;
    }
}

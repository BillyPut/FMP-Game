using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopIntro : MonoBehaviour
{
    public GameObject player;
    public GameObject introText;
    public GameObject buyText;
    public GameObject refuseText;
    public LevelManagerScript pauseCheck;
   
    
    public bool shopped = false;
    public bool shopping = false;
    public bool refused = false;
    public bool doneText = false;
    public float readTimer = 0.5f;
    public int collectibleAmount = 5;
    public PlayerScript collectibleTracker;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseCheck.inMenu == false)
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
                    pauseCheck.openMenu = false;
                    introText.SetActive(true);
                    shopping = true;

                }

            }

            if (shopping == true)
            {
                readTimer -= Time.unscaledDeltaTime;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            if (shopping == true && Input.GetKeyDown("e") && readTimer < 0 && doneText == false)
            {
                if (collectibleTracker.collectibles >= collectibleAmount)
                {
                    buyText.SetActive(true);
                    introText.SetActive(false);
                    doneText = true;


                }
                if (collectibleTracker.collectibles < collectibleAmount)
                {
                    refuseText.SetActive(true);
                    introText.SetActive(false);
                    readTimer = 0.5f;
                    doneText = true;
                    refused = true;

                }
            }

            if (refused == true && Input.GetKeyDown("e") && readTimer < 0)
            {
                refuseText.SetActive(false);
                shopping = false;
                doneText = false;
                readTimer = 0.5f;
                refused = false;
                pauseCheck.openMenu = true;
            }
        }





    }


    public void BoughtAbility()
    {
        buyText.SetActive(false);
        shopped = true;
        shopping = false;
        doneText = false;
        readTimer = 0.5f;
        pauseCheck.openMenu = true;
    }

    public void NotBoughtAbility()
    {
        buyText.SetActive(false);
        shopping = false;
        doneText = false;
        readTimer = 0.5f;
        pauseCheck.openMenu = true;
    }
}

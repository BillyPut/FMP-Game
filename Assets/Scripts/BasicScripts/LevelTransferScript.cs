using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransferScript : MonoBehaviour
{
    public GameObject player;
    public GameObject invisWall;
    public float fadeTimer;
    public bool animationPlay;
    public GameObject blackBox;
    public LevelManagerScript pauseCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (pauseCheck.inMenu == false)
        {
            fadeTimer -= Time.deltaTime;

            float ex = transform.position.x;
            float px = player.transform.position.x;

            float distx = ex - px;

            if (Input.GetKeyDown("e") && distx < 1.5f && distx > -1.5f)
            {
                pauseCheck.openMenu = false;
                invisWall.SetActive(true);
                blackBox.SetActive(true);
                fadeTimer = 2f;
                animationPlay = true;
                



            }

            if (animationPlay == true && fadeTimer <= 0)
            {
                SceneManager.LoadScene("Level2");
            }
        }

       

    }
}

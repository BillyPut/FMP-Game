using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStarterScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mainCanvas;
    public GameObject bossCamera;
    public GameObject bossWall;
    public GameObject healthCounter;
    public GameObject collectibleCounter;
    public GameObject bossCanvas;
    public GameObject boss;
    public LevelManagerScript stopPause;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            stopPause.openMenu = false;
            bossCamera.SetActive(true);
            bossWall.SetActive(true);
            bossCanvas.SetActive(true);
            boss.SetActive(true);
            mainCamera.SetActive(false);
            mainCanvas.SetActive(false);
            healthCounter.SetActive(false);
            collectibleCounter.SetActive(false);
           
            
            
        }
    }

}

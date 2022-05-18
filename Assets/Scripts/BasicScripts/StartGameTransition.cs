using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameTransition : MonoBehaviour
{
    private Animator anim;
    public GameObject text1;
    public GameObject text2;
    public bool startFade;
    public bool timerDown;
    public bool coroutineBegin;
    public float fadeTimer;
    public bool coroutineCheck;
    




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startFade == true)
        {
            
            fadeTimer = 10f;
            timerDown = true;
            startFade = false;
            coroutineCheck = true;

        }

        if (timerDown == true)
        {
            fadeTimer -= Time.deltaTime;
        }

        if (fadeTimer <= 0 && timerDown == true)
        {
            SceneManager.LoadScene("Level1");
        }

        if (fadeTimer <= 2 && timerDown == true)
        {
            anim.SetBool("Fade", true);
           
        }

        if (fadeTimer < 8 && coroutineBegin == false && coroutineCheck == true)
        {
            StartCoroutine(IntroCoroutine());
            coroutineBegin = true;
        }


    }


    public void BeginGame()
    {
        
        startFade = true;
        

        
    }

    IEnumerator IntroCoroutine()
    {
        text1.SetActive(true);

        yield return new WaitForSeconds(3);

        text2.SetActive(true);

    }

}

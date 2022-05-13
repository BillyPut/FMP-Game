using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameTransfer : MonoBehaviour
{
    public GameObject player;
    public GameObject text1;
    public GameObject text2;
    public float fadeTimer;
    public bool animationPlay;
    public bool startTransfer;
    public bool coroutineBegin;
    public bool timerDown;
    public GameObject blackBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


        if (startTransfer == true)
        {
            blackBox.SetActive(true);
            fadeTimer = 8f;
            animationPlay = true;

            timerDown = true;
            startTransfer = false;

        }

        if (timerDown = true)
        {
            fadeTimer -= Time.deltaTime;
        }

        if (animationPlay == true && fadeTimer <= 0)
        {
            SceneManager.LoadScene("Scene1");
        }

        if (fadeTimer < 6 && coroutineBegin == false && animationPlay == true)
        {
            StartCoroutine(TextCoroutine());
            coroutineBegin = true;
        }



    }

    IEnumerator TextCoroutine()
    {
        text1.SetActive(true);

        yield return new WaitForSeconds(3);

        text2.SetActive(true);

    }




}

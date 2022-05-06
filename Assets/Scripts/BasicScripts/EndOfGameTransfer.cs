using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameTransfer : MonoBehaviour
{
    public GameObject player;
    public float fadeTimer;
    public bool animationPlay;
    public bool startTransfer;
    public GameObject blackBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fadeTimer -= Time.deltaTime;


        if (startTransfer == true)
        {
            blackBox.SetActive(true);
            fadeTimer = 2f;
            animationPlay = true;

            startTransfer = false;

        }

        if (animationPlay == true && fadeTimer <= 0)
        {
            SceneManager.LoadScene("Scene1");
        }

    }
}

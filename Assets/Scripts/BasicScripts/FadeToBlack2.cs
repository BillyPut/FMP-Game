using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack2 : MonoBehaviour
{
    private Animator anim;
    public LevelTransferScript2 startAnimation;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnimation.animationPlay == true)
        {
            anim.SetBool("Fade", true);
        }
    }
}

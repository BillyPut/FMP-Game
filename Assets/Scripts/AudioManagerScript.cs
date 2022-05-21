using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    public Slider masterSlider;
    public AudioMixer audioMixer;

    public  AudioClip[] sounds;

    public string currentScene;

    public AudioSource masterSource;

    float mVolume;


    void Start()
    {
        currentScene = (SceneManager.GetActiveScene().name);

        StartCoroutine(SongRepeat());

        if (currentScene == "Scene1")
        {
            masterSource.PlayOneShot(sounds[0]);

        }
        if (currentScene == "Level1")
        {
            masterSource.PlayOneShot(sounds[1]);

        }
        if (currentScene == "Level2")
        {
            masterSource.PlayOneShot(sounds[2]);

        }
        if (currentScene == "Level3")
        {
            masterSource.PlayOneShot(sounds[3]);

        }



        if (PlayerPrefs.HasKey("volume"))
        {
            mVolume = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            PlayerPrefs.SetFloat("volume", -40f);
        }


        masterSlider.value = mVolume;

    }



    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    IEnumerator SongRepeat()
    {
        while (true)
        {
            if (currentScene == "Scene1")
            {
                yield return new WaitForSecondsRealtime(255.2f);
                masterSource.PlayOneShot(sounds[0]);
            }
            if (currentScene == "Level1")
            {
                yield return new WaitForSecondsRealtime(255.1f);
                masterSource.PlayOneShot(sounds[1]);
            }
            if (currentScene == "Level2")
            {
                yield return new WaitForSecondsRealtime(75.3f);
                masterSource.PlayOneShot(sounds[2]);
            }
            if (currentScene == "Level3")
            {
                yield return new WaitForSecondsRealtime(135.2f);
                masterSource.PlayOneShot(sounds[3]);
            }
        }
     
        
    }
}
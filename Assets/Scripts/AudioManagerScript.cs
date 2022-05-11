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

        if (currentScene == "Scene1")
        {
            masterSource.PlayOneShot(sounds[0]);

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


}
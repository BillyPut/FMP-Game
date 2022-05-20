using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{

    public TMP_Dropdown dropDown;
    public Toggle toggle;
    public bool isOn;


    void Start()
    {

        if (PlayerPrefs.GetInt("IsOn") == 1)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }

        toggle.isOn = isOn;







        if (PlayerPrefs.HasKey("drop") == true)
        {
            dropDown.value = PlayerPrefs.GetInt("drop");
        }
        else
        {
            PlayerPrefs.SetInt("drop", 5);
            dropDown.value = PlayerPrefs.GetInt("drop");
        }


    }

    void Update()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("IsOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("IsOn", 0);
        }
    }

   public void SetQuality (int qualityIndex)
   { 
      
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("drop", dropDown.value);
       
   }

   public void SetFullscreen (bool isFullscreen)
   {
        Screen.fullScreen = isFullscreen;
   }
}

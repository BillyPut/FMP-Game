using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{

    public GameObject startButton;
    public GameObject pauseMenu;

    public string currentScene;

    public bool inMenu;
    public bool openMenu = true;


    // Start is called before the first frame update
    void Start()
    {
        startButton.GetComponent<Button>().Select();
        Time.timeScale = 1;
        openMenu = true;
    }

    // Update is called once per frame
    void Update()
    {

        currentScene = (SceneManager.GetActiveScene().name);


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (currentScene != "Scene1" && inMenu == false && openMenu == true)
            {
                pauseMenu.SetActive(true);
                inMenu = true;
                
            }


        }

        if (inMenu == true)
        {
            Time.timeScale = 0;
        }
       




    }



    public void StartButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ResumeGame()
    {
        inMenu = false;
        Time.timeScale = 1;
        
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene1");
    }


}

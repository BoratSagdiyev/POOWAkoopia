using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static PauseMenu instance;
    public GameObject PauseCube;

    public void Awake()
    {
        instance = this;
    }
    public void PauseButton()
      
    {
        if (GameManager2.instance.pauseMenuEnabled)
        {
            Resume();
        }else
        {
            Pause();
        }
    }
    

    public void Resume ()
    {
        PauseCube.SetActive(true);
        GameManager2.instance.Resume();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        PauseCube.SetActive(false);
        Debug.Log("yes");
        GameManager2.instance.Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void LoadMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }


}

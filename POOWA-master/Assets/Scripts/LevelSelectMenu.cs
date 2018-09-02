using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public GameObject LoadPanel;


    public void Sceneload()
    {

        SceneManager.LoadScene("CoinsMode");
    }

    public Button[] levelButtons;
    
    
    void Start()
    {
        
        ReEnableButtons();
    }

    public void LoadLevel(int level)
    {
        int levelsCleared = PlayerPrefs.GetInt("LevelsCleared", 2);
        if (level <= levelsCleared + 1)
        {
            
            
            
            SceneManager.LoadScene(level);
            AdManager.instance.ShowInterstitialAd();
            Time.timeScale = 1f;


        }
    }

    void ReEnableButtons()
    {
        int levelsCleared = PlayerPrefs.GetInt("LevelsCleared", 0);
        for (int i = 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i <= levelsCleared -2);
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        ReEnableButtons();
    }

    public void Loading()
    {
        LoadPanel.SetActive(true);
    }


}
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {


    
    public GameManager gameManager;

    void OnTriggerEnter()
    {


        FindObjectOfType<AudioManager>().Play("Jee");
        UpdateClearedLevels();
        gameManager.CompleteLevel();
        
    }
    void UpdateClearedLevels()
    {
        int currentlyClearedLevels = PlayerPrefs.GetInt("LevelsCleared", 0);
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex > currentlyClearedLevels)
        {
            PlayerPrefs.SetInt("LevelsCleared", buildIndex);
            
        }
    }

}

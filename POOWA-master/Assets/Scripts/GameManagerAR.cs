using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using UnityEngine.UI;

public class GameManagerAR : MonoBehaviour
{

    
    bool gameHasEnded = false;
    

    public float restartDelay = 1f;

    public void Start()
    {
        Time.timeScale = 1f;
    }

   


    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            if (Coin.TaaraSigns > 49)
            {
                Debug.Log("TAARAEKSPERT");
                PlayGamesScript.UnlockAchievement(PGPS.achievement_taaraekspert);
            }
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
            

        }
    }
    void Restart()
    {
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


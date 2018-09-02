using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VeganFood : MonoBehaviour
{

    public GameObject GameOver;
    public GameObject PauseMenu;
    

    private void OnMouseDown()
    {

        if (GameManager2.instance.pauseMenuEnabled == false && GameManager2.instance.GameOverPanel == false)

        {
            GameManager2.instance.GameOverScreen();
            GameOver.SetActive(true);
            
            FindObjectOfType<AudioManager>().Play("PlayerCrash");
            Destroy(gameObject);
            FindObjectOfType<GameManagerAR>().EndGame();
        }
        
        
    }
}

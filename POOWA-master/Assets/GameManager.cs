using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    bool gameHasEnded = false;

  

    public PlayerMovement movement;
    
    public float restartDelay = 1f;
    

    public GameObject completelevelUI;

    

    public void CompleteLevel()
    {

        completelevelUI.SetActive(true);
    }




    public void EndGame()
    {
        
        if (gameHasEnded == false)
        {
            

            gameHasEnded = true;
            
            

            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);




        }

        

        
    }


    void Restart()
    {


        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }



}

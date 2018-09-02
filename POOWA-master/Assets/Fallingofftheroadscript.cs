using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingofftheroadscript : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter()
    {


        FindObjectOfType<AudioManager>().Play("Ei");
        
        gameManager.EndGame();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


    public static int TaaraSigns;

    private void Start()
    {
        CoinsManager.Coins = PlayerPrefs.GetInt("coins");
    }

    private void OnMouseDown()
    {
        if (GameManager2.instance.pauseMenuEnabled == false && GameManager2.instance.GameOverPanel == false)
        {

            

            FindObjectOfType<AudioManager>().Play("Unsks");
            Destroy(gameObject);
            TaaraSigns += 1;
            CoinsManager.Coins += 3;
            CoinsManager.instance.IncrementByThree();
            PlayerPrefs.SetInt("coins", CoinsManager.Coins);
            PlayerPrefs.Save();

        }
    }

    
}


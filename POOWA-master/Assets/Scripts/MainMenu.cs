using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   
    public GameObject ShopMenu;
    public GameObject CoverShopMenu;

    

    public void Start()
    {
        

        SaveManager.Instance.Load();
        
        StartCoroutine(ShopMenuCountDown(2f));
        
    }

    

    private IEnumerator ShopMenuCountDown(float waitTime)
    {
        FindObjectOfType<AudioManager>().Play("Khmkhm");
        //enable
        ShopMenu.SetActive(true);
        CoverShopMenu.SetActive(true);
        //wait for some time
        yield return new WaitForSecondsRealtime(waitTime); //realtime does not care about timescale
        //disable again
        ShopMenu.SetActive(false);
        CoverShopMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SaveManager.Instance.Save();
        Application.Quit();
    }
}
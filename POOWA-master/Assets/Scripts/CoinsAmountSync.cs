using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsAmountSync : MonoBehaviour {


    public Text CoinsAmount;

    public void Start()
    {
        CoinsManager.Coins = PlayerPrefs.GetInt("coins");
    }




    void Update () {
        CoinsAmount.text = CoinsManager.Coins.ToString();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();


    }
    





}

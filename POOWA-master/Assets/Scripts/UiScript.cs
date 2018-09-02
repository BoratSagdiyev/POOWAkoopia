using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{

    public static UiScript Instance { get; private set; }

    public Text[] ValueTextArray;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    public void UpdateAll()
    {
        for (int i = 0; i < GameManager2.ImportantValues.Length;)
            ValueTextArray[i].text = GameManager2.ImportantValues[i].ToString();
    }

    public void Save()
    {
        PlayGamesScript.instance.SaveData();
    }

    public void Increment(int index)
    {
        CoinsManager.Coins++;
        ValueTextArray[index].text = GameManager2.ImportantValues[index].ToString();
    }

    public void ShowAchievements()
    {
        PlayGamesScript.ShowAchievementsUI();
    }

    public void ShowLeaderboard()
    {
        PlayGamesScript.ShowLeaderboardUI();
    }





}
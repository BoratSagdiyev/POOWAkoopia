using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{

    public static int Coins { get; set; }
    public Text CoinsAmount;
    public static CoinsManager instance;
    void Awake()
    {

        instance = this;
    }


    

    public void Start()
    {
        Coins = PlayerPrefs.GetInt("CoinsAmount", Coins);
        
    }


    private void FixedUpdate()
    {
        
        

        PlayerPrefs.SetInt("CoinsAmount", Coins);
        CoinsAmount.text = Coins.ToString("0");
    }

    public void IncrementByOne()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 1);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 1);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 1);
    }

    public void IncrementByThree()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 3);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 3);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 3);
    }

    public void IncrementByFive()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 5);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 5);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 5);
    }

    public void IncrementByTen()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 10);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 10);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 10);
    }

    public void IncrementByTwenty()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 20);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 20);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 20);
    }

    public void IncrementByThirty()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 30);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 30);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 30);
    }

    public void IncrementByForty()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 40);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 40);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 40);
    }

    public void IncrementByFifty()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 50);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 50);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 50);
    }

    public void IncrementBySixty()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 60);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 60);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 60);
    }

    public void IncrementBy200()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 200);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 200);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 200);
    }

    public void IncrementBy14999()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 14999);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 14999);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 14999);
    }

    public void IncrementBy19999()
    {
        PlayGamesScript.IncrementAchievement(PGPS.achievement_collect_100_paw, 19999);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_thousandaire, 19999);
        PlayGamesScript.IncrementAchievement(PGPS.achievement_tenthousandaire, 19999);
    }

}

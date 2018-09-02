using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins7 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_8);
        CoinsManager.Coins += 50;
        CoinsManager.instance.IncrementByFifty();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

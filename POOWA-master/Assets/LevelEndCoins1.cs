using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins1 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_2);
        CoinsManager.Coins += 5;
        CoinsManager.instance.IncrementByFive();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

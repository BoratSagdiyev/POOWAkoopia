using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins3 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_4);
        CoinsManager.Coins += 10;
        CoinsManager.instance.IncrementByTen();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

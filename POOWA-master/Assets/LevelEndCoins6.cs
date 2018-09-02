using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins6 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_7);
        CoinsManager.Coins += 40;
        CoinsManager.instance.IncrementByForty();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

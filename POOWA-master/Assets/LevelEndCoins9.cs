using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins9 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_10);
        CoinsManager.Coins += 60;
        CoinsManager.instance.IncrementBySixty();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

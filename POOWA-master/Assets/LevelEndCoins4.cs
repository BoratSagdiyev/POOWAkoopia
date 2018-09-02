using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins4 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_5);
        CoinsManager.Coins += 20;
        //CoinsManager.instance.IncrementByTwenty();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

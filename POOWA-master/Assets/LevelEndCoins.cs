using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_1);
        CoinsManager.Coins += 5;
        CoinsManager.instance.IncrementByFive();
        Debug.Log("+5 coins");
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

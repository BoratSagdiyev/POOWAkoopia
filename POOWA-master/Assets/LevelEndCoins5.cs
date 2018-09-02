using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCoins5 : MonoBehaviour {

    private void OnTriggerEnter()
    {
        PlayGamesScript.UnlockAchievement(PGPS.achievement_complete_level_6);
        CoinsManager.Coins += 30;
        CoinsManager.instance.IncrementByThirty();
        PlayerPrefs.SetInt("coins", CoinsManager.Coins);
        PlayerPrefs.Save();
    }
}

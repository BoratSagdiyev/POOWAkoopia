using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turkishpipar : MonoBehaviour {

    bool SoundIsPlaying1 = false;
    public GameObject otherVersion;
    public GameObject thisVersion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && !SoundIsPlaying1)
        {
            SoundIsPlaying1 = true;
            FindObjectOfType<AudioManager>().Play("AeraNaepi");
            thisVersion.SetActive(false);
            otherVersion.SetActive(true);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
            PlayGamesScript.UnlockAchievement(PGPS.achievement_easter_egg_alert);


        }
    }
}

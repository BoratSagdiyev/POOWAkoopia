using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

    public GameObject gameOverHighScore;

    // Use this for initialization
    void Start () {
        StartCoroutine(GameOverScoreCountDown(2f));
    }

    private IEnumerator GameOverScoreCountDown(float waitTime)
    {
        FindObjectOfType<AudioManager>().Play("Khmkhm");
        //enable
        gameOverHighScore.SetActive(true);
        
        //wait for some time
        yield return new WaitForSecondsRealtime(waitTime); //realtime does not care about timescale
        //disable again
        gameOverHighScore.SetActive(false);
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}

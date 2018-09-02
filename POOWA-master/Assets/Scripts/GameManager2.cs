using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static int[] ImportantValues { get; set; }

    bool gameHasEnded = false;
    public bool GameOverPanel = false;

    public Text totalCoinText;

    public bool pauseMenuEnabled = false;

    public static GameManager2 instance;
    private void Awake()
    {

        instance = this;
        ImportantValues = new int[1];



    }



    private int totalCoin;
    public float restartDelay = 1f;


    public GameObject GameOver;
    public GameObject CoinsAmount;

    public Transform Jumper;
    public Text scoreText2D;
    public Text highScore;
    public float number;

    public void Start()
    {



        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
    }



    // Update is called once per frame
    void Update()
    {
        number = Jumper.position.y;
        scoreText2D.text = number.ToString("0");


        if (number > 200)
        {
            PlayGamesScript.UnlockAchievement(PGPS.achievement_get_a_high_score_of_200_in_coins_mode);
        }

        if (number > 500)
        {
            PlayGamesScript.UnlockAchievement(PGPS.achievement_500_in_coins_mode);
        }

        if (number > 1000)
        {
            PlayGamesScript.UnlockAchievement(PGPS.achievement_1000_in_coins_mode);
        }




        if (number > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayGamesScript.AddScoreToLeaderboard(PGPS.leaderboard_jumping_leaderboard, (long)number);
            PlayerPrefs.SetFloat("HighScore", number);
            highScore.text = number.ToString("0");
            PlayGamesScript.instance.SaveData();

        }


    }

    public void Pause()
    {
        pauseMenuEnabled = true;
    }
    public void Resume()
    {
        pauseMenuEnabled = false;
    }

    public void GameOverScreen()
    {
        GameOverPanel = true;
    }

    public void GameOverScreenOff()
    {
        GameOverPanel = false;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;
            CoinsAmount.SetActive(false);
            GameOver.SetActive(true);
            AdManager.instance.ShowInterstitialAd();



            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);






        }




    }


    void Restart()
    {



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0f;



    }



}
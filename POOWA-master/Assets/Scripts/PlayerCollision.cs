using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

    public float DownWardsForce = -1000;
    public PlayerMovement movement;
#pragma warning disable CS0436 // Type conflicts with imported type
    public GameManager gameManager;
#pragma warning restore CS0436 // Type conflicts with imported type
    public bool invincible = false;
    public Rigidbody rb;
    public float multiplier = 20f;
    public GameObject GameOver;
    public GameObject GameOver2;
    bool IsMainThemeMuted = false;


    public void OnCollisionEnter(Collision collisionInfo)


    {
        


        if (collisionInfo.collider.tag == "Obstacle")
        { 
        

            
            if (invincible) return;
            invincible = false;
            movement.enabled = false;
#pragma warning disable CS0436 // Type conflicts with imported type
            FindObjectOfType<GameManager>().EndGame();
#pragma warning restore CS0436 // Type conflicts with imported type
            

            foreach (AudioSource src in FindObjectsOfType<AudioSource>())
            {
                if (src.name != "PlayerCrash" || src.name != "ObstacleDestruction" || src.name != "MainTheme")

                    src.Pause();

            }


            GameOver.SetActive(true);
            FindObjectOfType<AudioManager>().Stop("Slowly");
            FindObjectOfType<AudioManager>().Play("PlayerCrash");
            FindObjectOfType<AudioManager>().Play("ObstacleDestruction");
            FindObjectOfType<AudioManager>().UnPause("MainTheme");







        }

        if (collisionInfo.collider.tag == "MetalBall")
        {


            if (invincible) return;
            invincible = false;
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

            foreach (AudioSource src in FindObjectsOfType<AudioSource>())
            {
                if (src.name != "PlayerCrash" || src.name != "MetalBall" || src.name != "MainTheme")

                    src.Pause();

            }
            GameOver2.SetActive(true);
            FindObjectOfType<AudioManager>().Play("PlayerCrash");
            FindObjectOfType<AudioManager>().Play("MetalBall");
            if (IsMainThemeMuted == false)
            {
                FindObjectOfType<AudioManager>().UnPause("MainTheme");
            }
        }
        




    }

    public void MainThemeMuted()
    {
        IsMainThemeMuted = true;
        FindObjectOfType<AudioManager>().Stop("MainTheme");

    }

    public void MainThemePlay()
    {
    
        IsMainThemeMuted = false;
        
        
        FindObjectOfType<AudioManager>().Play("MainTheme");
        
        
            
        
        

    }

    public void PowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Invincible:
                invincible = true;
                
                StartCoroutine(PowerUpCountdown(1.8f)); //TIMER

                break;
            case PowerUpType.GinTonic:

                rb.drag *= multiplier;
                StartCoroutine(PowerUpCountdown(3f));
                break;
            case PowerUpType.Jump:

                rb.AddForce(0, DownWardsForce * Time.deltaTime, 0, ForceMode.VelocityChange);

                break;
            case PowerUpType.GinTonic2:

                rb.drag *= multiplier;
                StartCoroutine(PowerUpCountdown(1f));
                break;
        }
    }


    IEnumerator PowerUpCountdown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        invincible = false;
        yield return new WaitForSeconds(waitTime);
        rb.drag /= multiplier;

    }

}

public enum PowerUpType
{
    Invincible,
    GinTonic,
    Jump,
    GinTonic2



}
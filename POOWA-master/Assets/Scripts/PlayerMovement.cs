using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{

    //Reference to "rb"
    public Rigidbody rb;

    private GameManager2 manager;
    public GameManager gamemanager;
    bool SoundIsPlaying = false;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public GameObject GameOver3;

    void Start()
    {
        SkinPanel.UpdateSkinMat();
        manager = FindObjectOfType<GameManager2>();
    }

    public void TransformPosition()
    {
        transform.position = new Vector3(0.0f, 1f, 0.0f);
    }



    public void right()
    {
        Debug.Log("right");
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    public void left()
    {
        Debug.Log("left");
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }




    // FixedUpdate undeprecated
    

    public void Update()
    {

        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Consistent on all machines


        if (rb.position.x < -8f && rb.position.y < 0.25f && !SoundIsPlaying)
        {
            GameOver3.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Ei");
            SoundIsPlaying = true;
            FindObjectOfType<GameManager>().EndGame();
        }
        if (rb.position.x > 8f && rb.position.y < 0.25f && !SoundIsPlaying)
        {
            GameOver3.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Ei");
            SoundIsPlaying = true;
            FindObjectOfType<GameManager>().EndGame();

        }
    }
   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    



    public float movementSpeed = 10f;
    float movement = 10f;

    public GameManager2 gameManager2;
    public Camera MainCamera;
    public GameObject GameOverInvisible;
   
   







    Rigidbody2D rb;
    Vector3 originalPos;

    

    


    int GetTouchDirection()
    {
        if (Input.touchCount < 1) return 0;

        Vector2 input = Input.GetTouch(0).position;
        Vector2 viewport = Camera.main.ScreenToViewportPoint(input);
        return viewport.x > 0.5f ? 1 : -1;
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        originalPos = gameObject.transform.position;
        




    }
    public void OnBecameInvisible()
    {
        
        
        
        
            if (MainCamera != null)
            {
                
               
             Debug.Log("yes");
            FindObjectOfType<AudioManager>().Play("PlayerCrash");

            FindObjectOfType<GameManager2>().EndGame();
             


             gameObject.transform.position = originalPos;
             Vector3 cameraPosition = MainCamera.transform.position;
             MainCamera.transform.position = new Vector3(cameraPosition.x, transform.position.x, cameraPosition.z);
                




            }
        

        
    }
    
    

    private void Update()
    {
        movement = GetTouchDirection() * movementSpeed;
        
        
        
        
    }

    public void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        

        
        
        


    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Taara"))
        {

            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("TaaraBig"))
        {

            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Vegan"))
        {
            
            
            
                
                FindObjectOfType<AudioManager>().Play("PlayerCrash");

                FindObjectOfType<GameManager2>().EndGame();

                gameObject.transform.position = originalPos;
                Vector3 cameraPosition = MainCamera.transform.position;
                MainCamera.transform.position = new Vector3(cameraPosition.x, transform.position.x, cameraPosition.z);
            
            

            
        }
        
    }

    

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
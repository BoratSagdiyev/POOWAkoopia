using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    //Reference to "rb"
    public Rigidbody rb;

    

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    

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
    public void FixedUpdate()
    {

        


        
        if (rb.position.y < 0f)
        {


            FindObjectOfType<GameManagerAR>().EndGame();
        }





    }

}

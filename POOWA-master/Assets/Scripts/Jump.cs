using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Rigidbody rb;
    public float duration = 4f;
    public float DownWardsForce = -1000;
    public float multiplier = 20f;
    public float BackWardsForce = -500;
    public PlayerMovement movement;



    public GameObject pickupEffect;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 250 * Time.deltaTime, 50 * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //Spawn effect
        FindObjectOfType<AudioManager>().Play("Burp");
        FindObjectOfType<AudioManager>().Play("PlasmaSound");
        FindObjectOfType<AudioManager>().Play("Koeha");




        player.GetComponent<PlayerCollision>().PowerUp(PowerUpType.Jump);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;


        
        rb.AddForce(0, DownWardsForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        rb.AddForce(0, DownWardsForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        movement.enabled = false;
        yield return new WaitForSeconds(duration);
        movement.enabled = true;
        



        Destroy(gameObject);

    }
}

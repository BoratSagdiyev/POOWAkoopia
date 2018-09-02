using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GinTonic2 : MonoBehaviour
{

    public Rigidbody rb;
    public float duration = 4f;
    public float DownWardsForce = -1000f;
    public float multiplier = 20f;
    public float BackWardsForce = -1000f;



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
        FindObjectOfType<AudioManager>().Play("SlowlyShorter");



        player.GetComponent<PlayerCollision>().PowerUp(PowerUpType.GinTonic2);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;


        rb.drag *= multiplier;
        rb.AddForce(0, DownWardsForce * Time.deltaTime, BackWardsForce * Time.deltaTime, ForceMode.VelocityChange);
        yield return new WaitForSeconds(duration);
        rb.drag /= multiplier;



        Destroy(gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeInvincibiltyMonster : MonoBehaviour {

    public float multiplier = 1.4f;
    public float duration = 4f;
    

    public GameObject pickupEffect;

    void Update()
    {
        transform.Rotate(0, 250 * Time.deltaTime, 50 * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //Spawn effect
        FindObjectOfType<AudioManager>().Play("Burp");
        FindObjectOfType<AudioManager>().Play("PlasmaSound");
        FindObjectOfType<AudioManager>().Play("InFlames");


        player.GetComponent<PlayerCollision>().PowerUp(PowerUpType.Invincible);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        

        player.transform.localScale *= multiplier;
        yield return new WaitForSeconds(duration);
        player.transform.localScale = player.transform.localScale / multiplier;


        Destroy(gameObject);

    }
}

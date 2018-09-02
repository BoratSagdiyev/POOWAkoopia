using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible2 : MonoBehaviour {

    public GameObject destroyedVersion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);

            
        }
    }
    
}

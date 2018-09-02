using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCoin : MonoBehaviour
{

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime);
        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("PickupSound");
            CoinsManager.Coins += 1;
            CoinsManager.instance.IncrementByOne();
            PlayerPrefs.SetInt("coins", CoinsManager.Coins);
            PlayerPrefs.Save();
            


        }
    }
   /* appID = "ca-app-pub-5698320091626063~2699602535"; //ca-app-pub-3940256099942544~3347511713
        bannerID = "ca-app-pub-3940256099942544/6300978111";
        interstitialID = "ca-app-pub-5698320091626063/7734121573";
        videoID = "ca-app-pub-5698320091626063/2714459100";
        nativeBannerID = "ca-app-pub-3940256099942544/2247696110";*/
}

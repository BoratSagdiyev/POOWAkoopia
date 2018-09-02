using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGenerator : MonoBehaviour
{



    public GameObject CoinPrefab;





    public float numberOfCoins = 999;
    public float CoinGap = 3f;
    public float minX = .2f;
    public float maxZ = 1.5f;
    public float YAmplitudeVegan = 10f;





    // Use this for initialization
    public void Start()
    {



        Vector3 spawnPosition = new Vector3();

        for (float i = 0; i < numberOfCoins; i++)
        {
            spawnPosition.z = Random.Range(100f, 0f);
            spawnPosition.x = Random.Range(-CoinGap, CoinGap);
            spawnPosition.y = Random.Range(20f, 0f);
            Instantiate(CoinPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
        }
    }
}
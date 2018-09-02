using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGenerator2 : MonoBehaviour
{



    public GameObject CoinPrefab;





    public float numberOfCoins = 999;
    public float CoinGap = 3f;
    public float minX = .2f;
    public float maxZ = 1.5f;
    public float YAmplitude = 10f;





    // Use this for initialization
    public void Start()
    {



        Vector3 spawnPosition = new Vector3();

        for (float i = 0; i < numberOfCoins; i++)
        {
            spawnPosition.z += Mathf.Lerp(minX, maxZ, (i / numberOfCoins));
            spawnPosition.x = Random.Range(-CoinGap, CoinGap);
            spawnPosition.y += Random.Range(-YAmplitude, YAmplitude);
            Instantiate(CoinPrefab, spawnPosition, Quaternion.Euler(-270, 0, 0));
        }
    }
}
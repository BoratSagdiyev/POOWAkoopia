using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour {

    public static LevelGenerator Instance { set; get; }

    public GameObject platformPrefab;
    public GameObject PickupPrefab;
    public GameObject VeganFoodPrefab;
    public GameObject TiluLiiPrefab;




    public float numberOfPlatforms = 999;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float numberOfPickups = 999;
    public float RangeOfPickups = 3f;
    public float minPickupY = .2f;
    public float maxPickupY = 1.5f;
    public float numberOfVeganFoods = 999;
    public float RangeOfVeganFoods = 3f;
    public float minVeganFoodY = .2f;
    public float maxVeganFoodY = 1.5f;
    public float numberOfTiluLiis = 999;
    public float RangeOfTiluLiis = 3f;
    public float minTiluLiiY = .2f;
    public float maxTiluLiiY = 1.5f;

    private void Start()
    {
        CoinsManager.Coins = PlayerPrefs.GetInt("coins");
        GenerateLevel();
        
    }


    public void Awake()
    {
       Instance = this;
    }


// Use this for initialization
public void GenerateLevel () {
        

        Vector3 spawnPosition = new Vector3();

        for (float i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Mathf.Lerp(minY, maxY, (i / numberOfPlatforms));
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
        Vector3 spawnPositionPickup = new Vector3();

        for (float i = 0; i < numberOfPickups; i++)
        {
            spawnPositionPickup.y += Mathf.Lerp(minPickupY, maxPickupY, (i / numberOfPickups));
            spawnPositionPickup.x = Random.Range(-RangeOfPickups, RangeOfPickups);
            Instantiate(PickupPrefab, spawnPositionPickup, Quaternion.identity);
        }
        
        Vector3 spawnPositionVeganFood = new Vector3();

        for (float i = 0; i < numberOfVeganFoods; i++)
        {
            spawnPositionVeganFood.y += Mathf.Lerp(minVeganFoodY, maxVeganFoodY, (i / numberOfVeganFoods));
            spawnPositionVeganFood.x = Random.Range(-RangeOfVeganFoods, RangeOfVeganFoods);
            Instantiate(VeganFoodPrefab, spawnPositionVeganFood, Quaternion.identity);
        }

        Vector3 spawnPositionTiluLii = new Vector3();

        for (float i = 0; i < numberOfTiluLiis; i++)
        {
            spawnPositionTiluLii.y += Mathf.Lerp(minTiluLiiY, maxTiluLiiY, (i / numberOfTiluLiis));
            spawnPositionTiluLii.x = Random.Range(-RangeOfTiluLiis, RangeOfTiluLiis);
            Instantiate(TiluLiiPrefab, spawnPositionTiluLii, Quaternion.identity);
        }

    }
	
	

    
}

using UnityEngine;
using UnityEngine.UI;

public class TaaraScript : MonoBehaviour {

    private void Start()
    {
        CoinsManager.Coins = PlayerPrefs.GetInt("coins");
    }

    public Transform TaaraSmall;
    
    void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.gameObject.CompareTag("Jumper"))
        {
#pragma warning disable CS0436 // Type conflicts with imported type
            CoinsManager.Coins++;
            CoinsManager.instance.IncrementByOne();
            PlayerPrefs.SetInt("coins", CoinsManager.Coins);
            PlayerPrefs.Save();
#pragma warning restore CS0436 // Type conflicts with imported type
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Unsks");
            PlayerPrefs.Save();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }








}

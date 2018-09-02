using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public struct Skin
{

    public string name;
    public int cost;
    public Material material;
    

    public Material GetDarkMaterial()
    {
        Material darkMat = material;
        darkMat.color = new Color(material.color.r * 0.75f, material.color.g * 0.75f, material.color.b * 0.75f, material.color.a);
        return darkMat;
    }
}

public class SkinPanel : MonoBehaviour
{
    public Skin[] skins;
    Renderer rend;

    public GameObject notEnoughCoins;
    public Transform skinPanel;
    public Text skinBuySetText;
    
    public static Skin activeSkin;
    void Update() { activeSkin = skins[activeSkinIndex]; }

    //call this when you buy / change skin, to update it
    public static void UpdateSkinMat()
    {
        Renderer playerRend = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
        playerRend.sharedMaterial = activeSkin.material;
    }



    public int selectedSkinIndex;
    public int activeSkinIndex;





    private void Start()
    {
        
        SaveManager.Instance.Load();


        rend = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.sharedMaterial = skins[activeSkinIndex].material;


        InitShop();
    }





    private void InitShop()
    {
        if (skinPanel == null)
            Debug.Log("You did not assign skinPanel");

        int i = 0;
        foreach (Button b in skinPanel.GetComponentsInChildren<Button>())
        {
            int currentIndex = i;

            b.onClick.AddListener(() => OnSkinSelect(currentIndex));

            //Set the skin of the image, based on if owned or not

            i++;
            Debug.Log("Adding handler for: " + currentIndex.ToString());



        }

        i = 0;


    }

    public void SetSkin(int index)
    {
        activeSkinIndex = index;
        skinBuySetText.text = "CURRENT";
    }

    private void OnSkinSelect(int currentIndex)
    {
        Debug.Log("selecting skin button: " + currentIndex);

        selectedSkinIndex = currentIndex;

        //Change the content of the but/set button, depending on the state of the color
        if (SaveManager.Instance.IsSkinOwned(currentIndex))
        {
            if (activeSkinIndex == currentIndex)
            {
                Debug.Log("current");
                skinBuySetText.text = "CURRENT";
            }
            else
            {
                Debug.Log("select");
                skinBuySetText.text = "SELECT";
            }
            //Skin is owned

        }
        else
        {
            //Skin isn't owned
            skinBuySetText.text = "BUY";
        }


    }




    public void OnSkinBuySet()
    {
        Debug.Log("Buy/set skin");

        //Is the selected skin owned
        if (SaveManager.Instance.IsSkinOwned(selectedSkinIndex))
        {
            //Set the skin!
            SetSkin(selectedSkinIndex);
            UpdateSkinMat();
            Debug.Log("Buy/set skin button");
            SaveManager.Instance.Save();

        }
        else
        {
            //Attempt to Buy the skin
            if (SaveManager.Instance.BuySkin(selectedSkinIndex, skins[selectedSkinIndex].cost))
            {
                //Success!
                SetSkin(selectedSkinIndex);
                
                SaveManager.Instance.Save();
            }
            else
            {
                //Do not have enough coins!
                //Play sound feedback


                StartCoroutine(NotEnoughCoinsCountdown(1f));



            }
        }
    }

    private IEnumerator NotEnoughCoinsCountdown(float waitTime)
    {
        //enable
        notEnoughCoins.SetActive(true);
        //wait for some time
        yield return new WaitForSecondsRealtime(waitTime); //realtime does not care about timescale
        //disable again
        notEnoughCoins.SetActive(false);
    }




}
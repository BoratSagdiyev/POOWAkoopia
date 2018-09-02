using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }

    public SaveState state;

    private void Awake()
    {
            if (Instance == null)
            {
            // Set single instance and make it persist between scenes
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Load();
            DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject); // destroy duplication
            }
        


    }

    public void Start()
    {
        
    }

    public void Save()
    {
        Debug.Log(Helper.Serialize<SaveState>(state));
        PlayerPrefs.SetString("save",Helper.Serialize<SaveState>(state));
        PlayerPrefs.Save();
        
    }

    public void Load()
    {
        Debug.Log(PlayerPrefs.GetString("save"));
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }

        else
        {
            state = new SaveState();
            Save();
            Debug.Log("no save file found, creating a new on");
        }
    }

    //Check if the skin is owned
    public bool IsSkinOwned(int index)
    {
        //Check if the bit is set, if so the color is owned
        return (state.skinsOwned & (1 << index)) != 0;
    }

    //Attempt buying a skin, return true/false
    public bool BuySkin (int index, int cost)
    {
        if (CoinsManager.Coins >= cost)
        {
            //Enough money, remove from the current coins stack
            CoinsManager.Coins -= cost;
            UnlockSkin(index);

            //Save progress
            Save();

            return true;
        }
        else
        {
            //Not enough money, return false
            return false;
        }
    }

    //Unlock a skin in the "skinOwned int
    public void UnlockSkin(int index)
    {
        //Toggle on the bit at index
        state.skinsOwned |= 1 << index;
    }

    //Reset the whole save file
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }


}

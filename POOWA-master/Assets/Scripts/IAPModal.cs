using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPModal : MonoBehaviour
{
    

    public void Buy9999()
    {
        IAPManager.Instance.Buy9999PAW();
    }

    public void Buy14999()
    {
        IAPManager.Instance.Buy14999PAW();
    }

    public void BuyNoAds()
    {
        IAPManager.Instance.BuyNoAds();
    }
}


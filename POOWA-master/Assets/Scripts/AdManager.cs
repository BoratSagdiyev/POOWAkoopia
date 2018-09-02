using UnityEngine;
using System.Collections;
using admob;
using System;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {
	Admob ad;
    private RewardBasedVideoAd rewardBasedVideo;
    
    string appID="";
	string bannerID="";
	string interstitialID= "";
	string videoID= "";
	string nativeBannerID = "";

    public static AdManager instance;
    


    private void Awake()
    {
        instance = this;
    }

    void Start () {
        Debug.Log("start unity demo-------------");
         initAdmob();
         CoinsManager.Coins = PlayerPrefs.GetInt("coins");
         rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdLoaded += HandleOnAdLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleOnAdOpening;
        rewardBasedVideo.OnAdStarted += HandleOnAdStarted;
        
        rewardBasedVideo.OnAdClosed += HandleOnAdClosed;
        rewardBasedVideo.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        ShowRewardedAd();





    }
	
	void Update () {
	    if (Input.GetKeyUp (KeyCode.Escape)) {
            Debug.Log(KeyCode.Escape+"-----------------");
	    }
    }
   
    void initAdmob()
    {
#if UNITY_IOS
        		 appID="ca-app-pub-3940256099942544~1458002511";
				 bannerID="ca-app-pub-3940256099942544/2934735716";
				 interstitialID="ca-app-pub-3940256099942544/4411468910";
				 videoID="ca-app-pub-3940256099942544/1712485313";
				 nativeBannerID = "ca-app-pub-3940256099942544/3986624511";
#elif UNITY_ANDROID
        appID = "ca-app-pub-5698320091626063~2699602535"; //ca-app-pub-3940256099942544~3347511713
        bannerID = "ca-app-pub-3940256099942544/6300978111";
        interstitialID = "ca-app-pub-5698320091626063/7734121573";
        videoID = "ca-app-pub-5698320091626063/2714459100";
        nativeBannerID = "ca-app-pub-3940256099942544/2247696110"; 
#endif

         ad = Admob.Instance();
            ad.bannerEventHandler += onBannerEvent;
            ad.interstitialEventHandler += onInterstitialEvent;
            ad.rewardedVideoEventHandler += onRewardedVideoEvent;
            ad.nativeBannerEventHandler += onNativeBannerEvent;
            ad.initSDK(appID);//optional
            ad.initAdmob(bannerID,interstitialID );//all id are admob test id,change those to your
                                                                                                             //ad.setTesting(true);//show test ad
            //ad.setNonPersonalized(true);//if want load NonPersonalized only,set true
           // ad.setIsDesignedForFamilies(true);//if is Is Designed For Families set true
           // ad.setGender(AdmobGender.MALE);
   		   //  string[] keywords = { "game","crash","male game"};
          //  ad.setKeywords(keywords);//set keywords for ad
            Debug.Log("admob inited -------------"+appID);
        
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        
    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       
    }
    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        
    }
    public void HandleOnAdStarted(object sender, EventArgs args)
    {
        
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
       
    }
    public void HandleOnAdRewarded(object sender, Reward args)
    {
        
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        
    }


    public void ShowInterstitialAd()
        {
        
           Debug.Log("touch inst button -------------");
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial();
            }
        }
        public void ShowRewardedAd()
        {
        //PleaseWait.SetActive(true);
        Debug.Log("touch video button -------------");
            if (ad.isRewardedVideoReady())
            {
                //RewardedButton.SetActive(false);
                ad.showRewardedVideo();
                rewardBasedVideo.OnAdRewarded += HandleOnAdRewarded;
                
        }
            else
            {
            	ad.loadRewardedVideo(videoID);
                
            }
        }

    
    /*if (GUI.Button(new Rect(0, 100, 100, 60), "showbanner"))
    {
        Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
    }
    if (GUI.Button(new Rect(120, 100, 100, 60), "showbannerABS"))
    {
        Admob.Instance().showBannerAbsolute(AdSize.Banner, 20, 300);
    }
    if (GUI.Button(new Rect(240, 100, 100, 60), "removebanner"))
    {
        Admob.Instance().removeBanner();
    }

    if (GUI.Button(new Rect(0, 200, 100, 60), "showNative"))
    {
        Admob.Instance().showNativeBannerRelative(new AdSize(320,100), AdPosition.BOTTOM_CENTER, 0,nativeBannerID);
    }
    if (GUI.Button(new Rect(120, 200, 100, 60), "showNativeABS"))
    {
        Admob.Instance().showNativeBannerAbsolute(new AdSize(-1,132), 20, 300, nativeBannerID);
    }
    if (GUI.Button(new Rect(240, 200, 100, 60), "removeNative"))
    {
        Admob.Instance().removeNativeBanner();
    }
}*/
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
        
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        if (eventName == AdmobEvent.onRewardedVideoCompleted)
        {
            Admob.Instance().showRewardedVideo();
            CoinsManager.Coins += 200;
            CoinsManager.instance.IncrementBy200();

            PlayerPrefs.SetInt("coins", CoinsManager.Coins);
            PlayerPrefs.Save();
        }

        if (eventName == AdmobEvent.onAdClosed)
        {
            
        }

    }
    void onNativeBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
    }
}

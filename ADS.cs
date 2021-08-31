using UnityEngine;
using System.Collections;
//using GoogleMobileAds.Api;
using System;
//using admob;

public class ADS : MonoBehaviour
{
    /*
    public actioncollider actioncolliderS;
    Admob ad;
    public GameObject LoseCanvas;
    public bool freeCoinsB;
    public snakemovements snakemovementsScript;
    string appID= "ca-app-pub-7906655820945626~9324235140";
    string bannerID = "ca-app-pub-7906655820945626/8535210734";
    string interstitialID = "ca-app-pub-7906655820945626/9132663452";
    string videoID = "ca-app-pub-7906655820945626/1254173430";
    string nativeBannerID = "ca-app-pub-7906655820945626/7560561488";
    void Awake()
    {
     //   Debug.Log("Awake is called!----------");
       // initAdmob();
    }

    void Start()
    {
        freeCoinsB = false;
      //  Debug.Log("start unity demo-------------");
       // Admob.Instance().showBannerRelative(bannerID, AdSize.SMART_BANNER, AdPosition.BOTTOM_CENTER);
        
       // ad.loadInterstitial(interstitialID);
        //ad.loadRewardedVideo(videoID);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(KeyCode.Escape + "-----------------");
        }

    }

    void initAdmob()
    {

        appID= "ca-app-pub-7906655820945626~9324235140";
        bannerID = "ca-app-pub-8906655820945626/8535210734";
        interstitialID = "ca-app-pub-7906655820945626/9132663452";
        videoID = "ca-app-pub-7906655820945626/1254173430";
        nativeBannerID = "ca-app-pub-7906655820945626/7560561488";

        AdProperties adProperties = new AdProperties();
        
               
                //adProperties.isAppMuted(true);
                adProperties.isUnderAgeOfConsent(false);
                adProperties.appVolume(0);
                adProperties.maxAdContentRating(AdProperties.maxAdContentRating_G);
        string[] keywords = { "racing", "cute", "minecraft","Disney" };
                adProperties.keyworks(keywords);
        
        ad = Admob.Instance();
        ad.bannerEventHandler += onBannerEvent;
        ad.interstitialEventHandler += onInterstitialEvent;
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.nativeBannerEventHandler += onNativeBannerEvent;
        ad.initSDK(adProperties);//reqired,adProperties can been null
    }
    
        public void RequestInterstitial()
    {
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial(interstitialID);
            }
        }
    public void showReward()
    {
        if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
                ad.loadRewardedVideo(videoID);
            }
        }
      
    public void freeCoins()
    {
        freeCoinsB = true;
        showReward();
    }
           
        
       

      
    
    void onInterstitialEvent(string eventName, string msg)
    {
      
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        if (eventName == AdmobEvent.onRewardedVideoCompleted)
        {
            if (freeCoinsB == false)
            {
                LoseCanvas.SetActive(false);
                actioncolliderS.ContinuePlaying();
            }
            else if(freeCoinsB == true)
            {
                snakemovementsScript.scorer += 20;
                snakemovementsScript.SaveCount();
                snakemovementsScript.ShowMainScore();
                freeCoinsB = false;
            }
        }
        if (eventName == AdmobEvent.onRewarded)
        {
            if (freeCoinsB == false)
            {
                LoseCanvas.SetActive(false);
                actioncolliderS.ContinuePlaying();
            }
            else if (freeCoinsB == true)
            {
                snakemovementsScript.scorer += 20;
                snakemovementsScript.SaveCount();
                snakemovementsScript.LoadCount();
                snakemovementsScript.ShowMainScore();
                freeCoinsB = false;
            }
        }
        else if (eventName == AdmobEvent.onRewardedAdFailToPresent)
        {
            showReward();
        }
        
       
        


    }
    void onNativeBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
    }
    


    */


}

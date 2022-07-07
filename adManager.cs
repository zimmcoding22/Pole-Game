using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class adManager : MonoBehaviour, IUnityAdsListener
{
    private string appStoreId = "3852680";
    private string playStoreId = "3852681";
    private string interstitialAd = "video";
    private string rewardVideoAd = "rewardedVideo";
    int backgroundSceneNo;
    public bool isTargetPlayStore;
    public bool isTestAd = true;


    void Start()
    {
        Advertisement.AddListener(this);
        backgroundSceneNo = 1;
        InitializeAdvertisement();
        PlayerPrefs.SetInt("play_ad", 0);
        //PlayerPrefs.SetInt("no_ads_bought", 0); //PlayerPrefs defaults to 0. Comment this line out when building.
        //PlayerPrefs.SetInt("moon_setting_bought", 0);
    }

    void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreId, isTestAd);
            return;
        } 
        Advertisement.Initialize(appStoreId, isTestAd);
        
    }

    public void playInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void playRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardVideoAd))
        {
            return;
        }
        Debug.Log("about to play reward ad");
        Advertisement.Show(rewardVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Failed:
                Debug.Log("ad failed");
                break;
            case ShowResult.Skipped:
                Debug.Log("ad skipped");
                break;
            case ShowResult.Finished:
                if (placementId == rewardVideoAd) //in this case, the reward will be to be able to continue playing the game
                {
                    Debug.Log("reward the player");
                    PlayerPrefs.SetInt("play_ad", 1);
                    SceneManager.LoadScene(backgroundSceneNo);
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("finished interstitial ad");
                }
                break;
        }
    }

}

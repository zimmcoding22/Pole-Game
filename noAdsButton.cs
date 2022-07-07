using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noAdsButton : MonoBehaviour
{

    public GameObject noAds;
   
    void Update()
    {
        //Debug.Log("no ads: " + PlayerPrefs.GetInt("no_ads_bought"));
        if (PlayerPrefs.GetInt("no_ads_bought") == 1 && noAds.activeSelf)
        {
            noAds.SetActive(false);
        }
    }
}

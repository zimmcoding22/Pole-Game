using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    static int sceneNo;
    int tcount;
    int currentScore;
    int streak;
    adManager ads;
    AudioSource birds;
    float mousePress;
    Scene scene;
    string sceneName;

    void Start()
    {
        currentScore = 0;
        streak = 1;
        sceneNo = 1;
        mousePress = 0;
        PlayerPrefs.SetInt("play_ad", 1);
    }

    void Update() {

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        if (Input.GetMouseButtonDown(0)) {
            mousePress = Input.mousePosition.y;
            tcount +=1;
            
        }
        if (tcount > 0 && mousePress < 1000)
        {
            Debug.Log("mouse press in scene switch: " + mousePress);
            tcount = 0;
            PlayerPrefs.SetInt("score", currentScore);
            PlayerPrefs.SetInt("streak", streak);
            System.Random rnd = new System.Random();
            int r = rnd.Next(0, 2);
            if (r == 1 && PlayerPrefs.GetInt("play_ad") == 1)
            {
                PlayerPrefs.SetInt("play_ad", 0);
            }
            if (PlayerPrefs.GetInt("play_ad") == 0 && PlayerPrefs.GetInt("no_ads_bought") == 0 && sceneName == "pole_game_over_scene")
            {
                ads = GameObject.Find("Play").GetComponent<adManager>();
                birds = GameObject.Find("Main Camera").GetComponent<AudioSource>();
                birds.mute = true;
                try
                {
                    ads.playRewardedVideoAd();
                } catch (Exception)
                {
                    Debug.Log("error playing ad");
                }
                
            } else
            {
                SceneManager.LoadScene(sceneNo);
            }
           
        }

    }
   
}

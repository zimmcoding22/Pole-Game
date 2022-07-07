using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class adjustPlatform : MonoBehaviour
{

    [SerializeField] GameObject BackLeftTree;
    [SerializeField] GameObject FrontLeftTree;
    [SerializeField] GameObject FrontRightTree;
    [SerializeField] GameObject BackLeftPalm;
    [SerializeField] GameObject FrontRightPalm;
    [SerializeField] GameObject BackLeftTreeNoLeaves;
    [SerializeField] GameObject FrontLeftTreeNoLeaves;
    [SerializeField] GameObject FrontRightTreeNoLeaves;
    GameObject ChooseSide;
    GameObject Righty;
    GameObject Lefty;
    GameObject Streak;
    GameObject BigStreakText;
    GameObject Score;
    GameObject WindSpeed;
    GameObject Time;
    GameObject Restart;
    GameObject RestartButton;
    GameObject FireworkReward;
    GameObject SupernovaReward;
    GameObject WindWarningLeft;
    GameObject WindWarningRight;
    GameObject TopWindWarning;
    GameObject TopRightArrow;
    GameObject TopLeftArrow;
    GameObject RightArrowRight;
    GameObject LeftArrowRight;
    GameObject RightArrowLeft;
    GameObject LeftArrowLeft;
    GameObject NoGravity;
    GameObject PoleTopHitText;
    GameObject NoAds;
    GameObject MoonSetting;
    GameObject HighScore;
    GameObject GameOver;
    GameObject Play; //tap to play again
    GameObject RestorePurchases;
    GameObject Title;

    Scene scene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        
        if (isTablet() != -1 && isTablet() != 2208 && isTablet() != 1334)
        {
            shiftGameObjects(sceneName);
        }
    }

    public static int isTablet()
    {
        int screenHeight = -1;
        int[] ipads = { 2224, 1668, 2048, 1536, 2732, 2048, 2208, 1242, 1334, 750 };
        Debug.Log("adjust platform start method");
        Debug.Log("screen height: " + Screen.height);
        Debug.Log("screen width: " + Screen.width);
        for (int x = 0; x < ipads.Length; x += 2)
        {
            if (ipads[x] == Screen.height && ipads[x + 1] == Screen.width)
            {
                screenHeight = ipads[x];
                if (ipads[x] == 2208)
                {
                    Debug.Log("this is an iphone 5.5 inch");
                } else if (ipads[x] == 1334) {
                    Debug.Log("this is an iphone 4.7 inch");
                } else
                {
                    Debug.Log("this is an ipad");
                }
                return(screenHeight);
            }
        }
        Debug.Log("this is an iphone");
        return(screenHeight);
    }

    void shiftGameObjects(string sceneName)
    {
        BackLeftTree.transform.position = new Vector3(-18, 1, 51);
        FrontLeftTree.transform.position = new Vector3(7, 3, 37);
        if (sceneName == "pole_game_over_scene")
        {
            Debug.Log("adjusting game over scene");
            FrontRightTree.transform.position = new Vector3(10, 3, 37);
            HighScore = GameObject.Find("HighScore");
            HighScore.GetComponent<RectTransform>().anchoredPosition = new Vector2(158, 200);
            Score = GameObject.Find("Score");
            Score.GetComponent<RectTransform>().anchoredPosition = new Vector2(158, 300);
            GameOver = GameObject.Find("GameOver");
            GameOver.GetComponent<RectTransform>().anchoredPosition = new Vector2(139, 430);
            NoAds = GameObject.Find("No Ads Button");
            NoAds.GetComponent<RectTransform>().anchoredPosition = new Vector2(-308, 172);
            MoonSetting = GameObject.Find("Moon Setting Button");
            MoonSetting.GetComponent<RectTransform>().anchoredPosition = new Vector2(-308, 60);
            Play = GameObject.Find("Play");
            Play.GetComponent<RectTransform>().anchoredPosition = new Vector2(360, -390);
        }
        else if (sceneName == "pole_game_background_scene")
        {
            //adjust background
            FrontRightTree.transform.position = new Vector3(-31, -315, 485);
            Debug.Log("adjusting main background scene");
            ChooseSide = GameObject.Find("Choose Side");
            ChooseSide.GetComponent<RectTransform>().anchoredPosition = new Vector2(250, -380);
            Lefty = GameObject.Find("Lefty");
            Lefty.GetComponent<RectTransform>().anchoredPosition = new Vector2(541, -450);
            Righty = GameObject.Find("Righty");
            Righty.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -450);
            Score = GameObject.Find("Score");
            Score.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 430);
            WindSpeed = GameObject.Find("Wind Speed");
            WindSpeed.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 370);
            Time = GameObject.Find("Time");
            Time.GetComponent<RectTransform>().anchoredPosition = new Vector2(569, 430);
            Restart = GameObject.Find("Restart");
            Restart.GetComponent<RectTransform>().anchoredPosition = new Vector2(569, 370);
            RestartButton = GameObject.Find("Restart Button");
            RestartButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(331, 425);
            BackLeftTreeNoLeaves.transform.position = new Vector3(-18, .25f, 50);
            FrontRightTreeNoLeaves.transform.position = new Vector3(15, 0, 37);
            BackLeftPalm.transform.position = new Vector3(-13, .25f, 50);
            FrontRightPalm.transform.position = new Vector3(15, 0, 37);
            BigStreakText = GameObject.Find("Big Streak");
            BigStreakText.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 310);
            Streak = GameObject.Find("Streak");
            Streak.GetComponent<RectTransform>().anchoredPosition = new Vector2(570, 200);
            FireworkReward = GameObject.Find("Firework Reward");
            FireworkReward.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, 150);
            SupernovaReward = GameObject.Find("Supernova Reward");
            SupernovaReward.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, 150);
            NoGravity = GameObject.Find("No Gravity");
            NoGravity.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, 250);
            PoleTopHitText = GameObject.Find("Pole Top Hit Text");
            PoleTopHitText.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, 250);
            WindWarningLeft = GameObject.Find("Wind Warning Left");
            WindWarningLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(55, -380);
            WindWarningRight = GameObject.Find("Wind Warning Right");
            WindWarningRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(585, -380);
            TopWindWarning = GameObject.Find("Top Wind Warning");
            TopWindWarning.GetComponent<RectTransform>().anchoredPosition = new Vector2(345, 250);
            TopRightArrow = GameObject.Find("Top Right Arrow");
            TopRightArrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(-10, 250);
            TopLeftArrow = GameObject.Find("Top Left Arrow");
            TopLeftArrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(-10, 250);
            RightArrowRight = GameObject.Find("Right Arrow Right");
            RightArrowRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(275, -385);
            RightArrowLeft = GameObject.Find("Right Arrow Left");
            RightArrowLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-273, -385);
            LeftArrowRight = GameObject.Find("Left Arrow Right");
            LeftArrowRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(275, -385);
            LeftArrowLeft = GameObject.Find("Left Arrow Left"); 
            LeftArrowLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-273, -385);

        }
        else //title scene
        {
            Debug.Log("adjusting title scene");
            FrontRightTree.transform.position = new Vector3(10, 3, 37);
            Title = GameObject.Find("Title");
            Title.GetComponent<RectTransform>().anchoredPosition = new Vector2(127, 420);
            HighScore = GameObject.Find("HighScore");
            HighScore.GetComponent<RectTransform>().anchoredPosition = new Vector2(32, 250);
            NoAds = GameObject.Find("No Ads Button");
            NoAds.GetComponent<RectTransform>().anchoredPosition = new Vector2(-308, 320);
            MoonSetting = GameObject.Find("Moon Setting Button");
            MoonSetting.GetComponent<RectTransform>().anchoredPosition = new Vector2(-308, 200);
            RestorePurchases = GameObject.Find("Restore Purchases");
            RestorePurchases.GetComponent<RectTransform>().anchoredPosition = new Vector2(-291, 80);
            Play = GameObject.Find("Play");
            Play.GetComponent<RectTransform>().anchoredPosition = new Vector2(95, -100);

        }
    }
}
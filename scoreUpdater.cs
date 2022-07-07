using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//takes care of carrying score across scenes
public class scoreUpdater : MonoBehaviour
{
    public GameObject Score;
    public GameObject HighScore;
    Scene scene;
    string sceneName;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

 
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("in update for score update");
        //Debug.Log("high score: " + PlayerPrefs.GetInt("high_score"));
        if (sceneName == "pole_game_over_scene")
        {
            //Debug.Log("in game over scene");
            Score.GetComponent<Text>().text = "FINAL SCORE: " + Convert.ToString(PlayerPrefs.GetInt("score"));
            HighScore.GetComponent<Text>().text = "HIGH SCORE: " + Convert.ToString(PlayerPrefs.GetInt("high_score"));
        }
        if (sceneName == "pole_game_title_scene")
        {
            //Debug.Log("in background scene");
            Score.GetComponent<Text>().text = "HIGH SCORE: " + Convert.ToString(PlayerPrefs.GetInt("high_score"));
        }
        
    }
}

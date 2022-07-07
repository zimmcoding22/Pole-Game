using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class poleCollision : MonoBehaviour
{
    public AudioSource poleHitSound;
    public GameObject Score;
    public GameObject streakText;
    public GameObject BigStreakText;
    public GameObject noGravityText;
    public GameObject poleTop;
    public GameObject globalScripts;
    public GameObject moonRock;
    changeBackdrop backdrop;
    private bool hasCollided;
    public bool collisionsOn;
    protected int streak;


    // Start is called before the first frame update
    void Start()
    {
        poleHitSound = GetComponent<AudioSource>();
        globalScripts = GameObject.Find("GlobalScripts");
        backdrop = globalScripts.GetComponent<changeBackdrop>();
        hasCollided = false;
        streak = PlayerPrefs.GetInt("streak");
        collisionsOn = true;
        Debug.Log("current streak: " + streak);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Puck" && collisionsOn)
        {
            hasCollided = true;
            poleHitSound.Play(0);
            collisionsOn = false;
            //Debug.Log("pole has been hit: " + col.relativeVelocity.magnitude);
       
        }
    }
                
    void FixedUpdate()
    {
  
        if (hasCollided)
        {
            string score_text = Score.GetComponent<Text>().text;
            int starting_char = score_text.IndexOf(" ") + 1; //get just score
            int s = Convert.ToInt32(score_text.Substring(starting_char)); //current score as an int
            //Debug.Log("s: " + s);
            streak = PlayerPrefs.GetInt("streak");
            string streak_string = Convert.ToString(PlayerPrefs.GetInt("streak"));
            streakText.GetComponent<Text>().text = '+' + streak_string;
            if (streak > 1)
            {
                streakText.GetComponent<Text>().enabled = true;
            }
            if (streak > 2)
            {
                streakText.GetComponent<Text>().color = Color.black;
                streakText.GetComponent<Text>().enabled = true;
            }
            if (streak > 3)
            {
                BigStreakText.GetComponent<Text>().enabled = true;
               
            }
            if (streak > 10)
            {
                streakText.GetComponent<Text>().color = Color.blue;
            }
            if (streak % 3 == 0 && !moonRock.activeSelf) //scene switch
            {
                System.Random rnd = new System.Random();
                int setting;
                if (PlayerPrefs.GetInt("moon_setting_bought") == 0)
                {
                    Debug.Log("moon setting not purchased");
                    setting = rnd.Next(1, 3);
                } else
                {
                    Debug.Log("moon setting purchased");
                    setting = rnd.Next(1, 4);
                }
                //setting = 3;
                if (setting == 3)
                {
                    noGravityText.GetComponent<Text>().enabled = true;
                }
                backdrop.changeSetting(setting);
            }
            PlayerPrefs.SetInt("score", s + streak);
            if (s + streak > PlayerPrefs.GetInt("high_score"))
            {
                PlayerPrefs.SetInt("high_score", s + streak);
            }
            Score.GetComponent<Text>().text = "SCORE: " + Convert.ToString(s + streak);
            //use scoreSwitch obj here
            PlayerPrefs.SetInt("streak", streak + 1);
            hasCollided = false;
        }
    
    }    
}

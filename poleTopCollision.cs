using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class poleTopCollision : poleCollision
{
    private int poleTopReward;
    private bool hasCollidedTop;
    public bool collisionsOnTop;
    public GameObject poleTopHitText;
    public GameObject fireworkReward;
    public GameObject supernovaReward;
    public GameObject poleParticles;
    public GameObject Firework;
    public GameObject Supernova;
    public GameObject Coastline;
    public GameObject CoastlineSnow;
    public GameObject CoastlineSand;
    public GameObject Pole;
    AudioSource poleHitTopSound;

    void Start()
    {
        Debug.Log("pole top script started");
        poleTopReward = 20;
        hasCollidedTop = false;
        collisionsOnTop = true;
        poleHitTopSound = Pole.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("collisions? " + base.collisionsOn);
        if (col.gameObject.tag == "Puck" && collisionsOnTop)
        {
            Debug.Log("pole top collision");
            hasCollidedTop = true;
            collisionsOnTop = false;
        }
    }

    void FixedUpdate()
    {

        if (hasCollidedTop)
        {
            Debug.Log("top of the pole has been hit!");
            hasCollidedTop = false;
            try
            {
                string score_text = base.Score.GetComponent<Text>().text;
                int starting_char = score_text.IndexOf(" ") + 1;
                int s = Convert.ToInt32(score_text.Substring(starting_char));
                string streak_string = Convert.ToString(PlayerPrefs.GetInt("streak"));
                base.streakText.GetComponent<Text>().text = '+' + streak_string;
                base.streakText.GetComponent<Text>().enabled = true;
                poleHitTopSound.Play(0);
                if (poleParticles.activeSelf)
                {
                    if (base.moonRock.activeSelf)
                    {
                        //play supernova
                        poleTopReward = 80;
                        Supernova.SetActive(true);
                        supernovaReward.GetComponent<Text>().enabled = true;
                    } else
                    {
                        poleTopReward = 40;
                        fireworkReward.GetComponent<Text>().enabled = true;
                        //play firework
                        Firework.SetActive(true);
                    }
                    if (!base.moonRock.activeSelf)
                    {
                        changeBackdrop backdrop = base.globalScripts.GetComponent<changeBackdrop>();
                        System.Random rnd = new System.Random();
                        int setting;
                        if (Coastline.activeSelf)
                        {
                            if (PlayerPrefs.GetInt("moon_setting_bought") == 0) //hasn't been purchased
                            {
                                setting = rnd.Next(1, 3);
                            }
                            else
                            {
                                setting = rnd.Next(1, 4);
                            }
                        }
                        else if (CoastlineSnow.activeSelf)
                        {
                            if (PlayerPrefs.GetInt("moon_setting_bought") == 0)
                            {
                                setting = rnd.Next(2, 3);
                            }
                            else
                            {
                                setting = 3;
                            }
                        }
                        else
                        {
                            if (PlayerPrefs.GetInt("moon_setting_bought") == 0)
                            {
                                setting = rnd.Next(0, 3);
                            }
                            else
                            {
                                setting = 3;
                            }
                        }
                        if (setting == 3)
                        {
                            base.noGravityText.GetComponent<Text>().enabled = true;
                        }
                        backdrop.changeSetting(setting);
                    } 
                    Debug.Log("current score firework: " + s + " steak: " + PlayerPrefs.GetInt("streak") + " pole top reward: " + poleTopReward);
                    base.Score.GetComponent<Text>().text = "SCORE: " + Convert.ToString(s + PlayerPrefs.GetInt("streak") + poleTopReward);
                } else
                {
                    poleTopReward = 20;
                    Debug.Log("current score: " + s + " steak: " + PlayerPrefs.GetInt("streak") + " pole top reward: " + poleTopReward);
                    poleTopHitText.GetComponent<Text>().enabled = true;
                    base.Score.GetComponent<Text>().text = "SCORE: " + Convert.ToString(s + PlayerPrefs.GetInt("streak") + poleTopReward);
                }
                PlayerPrefs.SetInt("score", s + PlayerPrefs.GetInt("streak") + poleTopReward);
                if ((s + PlayerPrefs.GetInt("streak") + poleTopReward) > PlayerPrefs.GetInt("high_score"))
                {
                    PlayerPrefs.SetInt("high_score", s + PlayerPrefs.GetInt("streak") + poleTopReward);
                }
                PlayerPrefs.SetInt("streak", PlayerPrefs.GetInt("streak") + 1);
            } catch (Exception e)
            {
                Debug.Log("error in pole top collision: " + e);
            }
        }
    }
}

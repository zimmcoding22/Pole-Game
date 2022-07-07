using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class moveFalcon : MonoBehaviour
{

    public GameObject bird;
    public Transform[] target;
    private int current;
    private int birdReward;
    float speed;
    public bool bird_flying;
    public AudioSource hitFalcon;
    public GameObject streakText;
    public GameObject Score;
    public bool collisionsOn;
    public bool hasCollided;
    //public Camera birdRaycast;
    Rigidbody rb;


    void Start()
    {
        //Debug.Log("in start falcon method");
        //Debug.Log("no ads bought: " + PlayerPrefs.GetInt("no_ads_bought"));
        //Debug.Log("bird rotation in move: " + bird.transform.rotation);
        collisionsOn = true;
        hasCollided = false;
        bird_flying = false;
        birdReward = 10;
        try
        {
            resetBird();
        } catch (NullReferenceException)
        {
            Debug.Log("error");
        }
    }

    void FixedUpdate()
    {
      
        if (hasCollided)
        {
            resetBird();
            string score_text = Score.GetComponent<Text>().text;
            int starting_char = score_text.IndexOf(" ") + 1; //get just score
            int s = Convert.ToInt32(score_text.Substring(starting_char)); //current score as an int
            streakText.GetComponent<Text>().text = "+10";
            streakText.GetComponent<Text>().enabled = true;
            Score.GetComponent<Text>().text = "SCORE: " + Convert.ToString(s + birdReward);
            PlayerPrefs.SetInt("score", s + birdReward);
            hasCollided = false;
        }
        if (transform.position.x != target[current].position.x && bird_flying)
        {
            //Debug.Log("falcon flying toward target");
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            rb = bird.GetComponent<Rigidbody>();
            //m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            rb.MovePosition(pos);
        }
        else
        {
            if (bird_flying)
            {
                //Debug.Log("falcon reached target");
                bird_flying = false;
                resetBird();
            }
            current = (current + 1) % target.Length;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Puck" && collisionsOn)
        {
            Debug.Log("bird has been struck");
            hitFalcon.Play(0);
            bird_flying = false;
            hasCollided = true;
            collisionsOn = false;
        }
            
    }

    public void resetBird()
    {
        //bring bird back to starting position
        System.Random rnd = new System.Random();
        float bird_height = (float)rnd.Next(5, 16);
        float bird_side = -17;
        speed = (float)rnd.Next(2, 6);
        //-12 to start from left, 15 to start from right
        int side = rnd.Next(0, 2);
        if (side != 0)
        {
            bird_side = 27f;
        } else
        {
            bird_side = -17f;
        }
        if (bird_side == 27)
        {
            target[current].transform.position = new Vector3(-17, bird_height, 26);
        } else
        {
            target[current].transform.position = new Vector3(27, bird_height, 26);
        }

        bird.transform.position = new Vector3(bird_side, bird_height, 26.0f);
        bird.transform.rotation = new Quaternion(-0.1f, 0.7f, 0.1f, 0.7f); //reset to original rotation
        if (bird_side == 27)
        {
            bird.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        bird.GetComponent<Animation>().enabled = true;
    }

}

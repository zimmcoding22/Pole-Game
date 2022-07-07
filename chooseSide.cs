using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class chooseSide : MonoBehaviour
{

    public GameObject GlobalScripts;
    float mousePressX;
    Timer timer;
    int screenDivider = 550;
    public GameObject rightStick;
    public GameObject leftStick;
    public GameObject chooseSideText;
    public GameObject leftyText;
    public GameObject rightyText;
    public GameObject swipeInstruction;
    public GameObject Time;
    AudioSource startWhistle;
    GameObject Puck;
    movePuck move_puck;

    // Start is called before the first frame update
    void Start()
    {
        timer = GlobalScripts.GetComponent<Timer>();
        Puck = GameObject.Find("Puck");
        move_puck = Puck.GetComponent<movePuck>();
        leftStick.transform.position = new Vector3(.94f, 1.23f, 3.01f); //sticks start in the middle, but appear to start in lefty righty positions. This is so the animations work correctly
        rightStick.transform.position = new Vector3(-.56f, 2.04f, 2.38f);
        startWhistle = Time.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.startTimer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePressX = Input.mousePosition.x;
                
            }
            if (mousePressX != 0 && mousePressX < screenDivider) //righty
            {
                //Debug.Log("RIGHTY selected: " + mousePressX);
                rightStick.transform.position = new Vector3(.42f, 2.04f, 2.52f);
                timer.startTimer = true;
                disableText(true);
            }
            if (mousePressX != 0 && mousePressX > screenDivider) //lefty
            {
                //Debug.Log("LEFTY selected");
                leftStick.transform.position = new Vector3(.03f, 1.23f, 3.01f);
                timer.startTimer = true;
                disableText(false);
            }
        }
    }

    void disableText(bool side)
    {
        if (side)//righty
        {
            Debug.Log("left stick deactivated");
            leftStick.SetActive(false);
        } else
        {
            Debug.Log("right stick deactivated");
            rightStick.SetActive(false);
        }
        chooseSideText.SetActive(false);
        leftyText.SetActive(false);
        rightyText.SetActive(false);
        move_puck.enabled = true;
        swipeInstruction.SetActive(true);
        startWhistle.enabled = true;
    }
}

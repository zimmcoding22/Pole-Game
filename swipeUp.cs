using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class swipeUp : MonoBehaviour
{
    movePuck puck;

    //y coordinates because we are dealing with a swipe up
    public float mousePress = 0f;
    public float mouseRelease = 0f;
    public Vector3 inputPositionUp;
    public Vector3 inputPositionDown;
    private bool hasReleased = false;
    public Animator animController;
    private float mousePressStartTime;
    public float time_elapsed = 0f;


    //initialize here
    void Start()
    {
        Debug.Log("swipe detection script");
        animController = GetComponent<Animator>();
        puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<movePuck>();

    }
    // Update is called once per frame
    void Update()
    {
        animController.SetBool("playShot", false);
        if (Input.GetMouseButtonDown(0))
        {
            mousePressStartTime = Time.time;
            inputPositionDown = Input.mousePosition;
            mousePress = Input.mousePosition.y;
            hasReleased = false;
        }
     
        if (Input.GetMouseButtonUp(0))
        {
            time_elapsed = Time.time - mousePressStartTime;
            //Debug.Log("time elapsed: " + time_elapsed);
            inputPositionUp = Input.mousePosition;
            mouseRelease = Input.mousePosition.y;
            hasReleased = true;
        }

        //if there was an up swipe
        if (mouseRelease > mousePress && mousePress != 0 && mouseRelease != 0 && hasReleased) 
        {
            //Debug.Log("time elapsed in swipe: " + time_elapsed);
            //Debug.Log("input position down: " + inputPositionDown);
            //Debug.Log("input position up: " + inputPositionUp);
            //Debug.Log("bool value: " + animController.GetBool("playShot"));
            //call move function from within movePuck class
            puck.Move();
            mousePress = 0;
            mouseRelease = 0;

        }
    }
}

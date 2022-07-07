using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class windArea : MonoBehaviour
{

    //append rigidbody to list and apply force to it if it collides with the wind area
    List<Rigidbody> RigidbodiesInWindZoneList = new List<Rigidbody>();
    Vector3 windDirection;
    public GameObject flag;
    public GameObject flag_two;
    public GameObject no_wind_flag;
    public GameObject Wind;
    public GameObject WindWarningLeft;
    public GameObject WindWarningRight;
    public GameObject LeftArrowLeft;
    public GameObject RightArrowRight;
    public GameObject LeftArrowRight;
    public GameObject RightArrowLeft;
    public GameObject TopWindWarning;
    public GameObject TopLeftArrow;
    public GameObject TopRightArrow;
    public GameObject stick;
    int windStrength;
    Color red_color;

    void Start()
    {
        Debug.Log("start");
        red_color = new Color32(185, 39, 46, 255);
    }

    private void OnTriggerEnter(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();
        if (objectRigid != null)
        {
            if (col.gameObject.tag != "bird") // don't let the wind blow the bird
            {
                RigidbodiesInWindZoneList.Add(objectRigid);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();
        if (objectRigid != null)
        {
            RigidbodiesInWindZoneList.Remove(objectRigid);
        }
    }

    public void SetWindStrengthAndDirection(int w, int d)
    {
        windStrength = w;
        if (windStrength != 0)
        {
            
            TopWindWarning.GetComponent<Text>().enabled = true;
            TopWindWarning.GetComponent<Text>().text = "WIND: " + Convert.ToString(windStrength);
            if (stick.activeSelf) //right stick is active, so show wind on the right side
            {
                WindWarningRight.GetComponent<Text>().enabled = true;
                WindWarningRight.GetComponent<Text>().text = "WIND: " + Convert.ToString(windStrength);
            } else
            {
                WindWarningLeft.GetComponent<Text>().enabled = true;
                WindWarningLeft.GetComponent<Text>().text = "WIND: " + Convert.ToString(windStrength);
            }
            if (d == 0)
            {
                windDirection = Vector3.left;
                flag.SetActive(false);
                flag_two.SetActive(true);
                no_wind_flag.SetActive(false);
                TopLeftArrow.GetComponent<SVGImage>().enabled = true;
                if (stick.activeSelf)
                {
                    LeftArrowRight.GetComponent<SVGImage>().enabled = true;
                    LeftArrowLeft.GetComponent<SVGImage>().enabled = false;
                } else
                {
                    LeftArrowLeft.GetComponent<SVGImage>().enabled = true;
                    LeftArrowRight.GetComponent<SVGImage>().enabled = false;
                }
                RightArrowRight.GetComponent<SVGImage>().enabled = false;
                RightArrowLeft.GetComponent<SVGImage>().enabled = false;
                TopRightArrow.GetComponent<SVGImage>().enabled = false;
            }
            else
            {
                windDirection = Vector3.right;
                flag.SetActive(true);
                flag_two.SetActive(false);
                no_wind_flag.SetActive(false);
                TopRightArrow.GetComponent<SVGImage>().enabled = true;
                if (stick.activeSelf)
                {
                    RightArrowRight.GetComponent<SVGImage>().enabled = true;
                    RightArrowLeft.GetComponent<SVGImage>().enabled = false;
                } else
                {
                    RightArrowLeft.GetComponent<SVGImage>().enabled = true;
                    RightArrowRight.GetComponent<SVGImage>().enabled = false;
                }
                LeftArrowLeft.GetComponent<SVGImage>().enabled = false;
                LeftArrowRight.GetComponent<SVGImage>().enabled = false;
                TopLeftArrow.GetComponent<SVGImage>().enabled = false;
            }
        }
        else
        {
            RightArrowRight.GetComponent<SVGImage>().enabled = false;
            LeftArrowRight.GetComponent<SVGImage>().enabled = false;
            RightArrowLeft.GetComponent<SVGImage>().enabled = false;
            LeftArrowLeft.GetComponent<SVGImage>().enabled = false;
            WindWarningLeft.GetComponent<Text>().enabled = false;
            WindWarningRight.GetComponent<Text>().enabled = false;
            TopWindWarning.GetComponent<Text>().enabled = false;
            TopLeftArrow.GetComponent<SVGImage>().enabled = false;
            TopRightArrow.GetComponent<SVGImage>().enabled = false;
            flag.SetActive(false);
            flag_two.SetActive(false);
            no_wind_flag.SetActive(true);
        }

        Wind.GetComponent<Text>().text = "WIND SPEED: " + Convert.ToString(windStrength);
        if (windStrength != 0)
        {
            Wind.GetComponent<Text>().color = red_color;
        } else
        {
            Wind.GetComponent<Text>().color = Color.white;
        }
        //Debug.Log("wind strength: " + windStrength + " direction: " + windDirection);
    }

    private void FixedUpdate()
    {
        if (RigidbodiesInWindZoneList.Count > 0)
        {
            foreach (Rigidbody rigid in RigidbodiesInWindZoneList)
            {
                rigid.AddForce(windDirection * windStrength);
            }
        }
    }
}

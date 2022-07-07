using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is used to grab screenshots for the required app store connect formats
public class screenShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("screen shot start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot("/Users/jakezimmerman/Documents/screenShot.png");
        }
    }
}
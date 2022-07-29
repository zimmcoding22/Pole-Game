using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 50f;
    int sceneNo = 2; //game over scene
    public bool startTimer = false;

    public Text countDownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = "TIME: " + currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                SceneManager.LoadScene(sceneNo);
            }
        }
        
    }
}

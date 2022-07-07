using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
   static int sceneNo = 1;
   int currentScore;
   int streak;

   void Start()
   {
        currentScore = 0;
        streak = 1;
   }

   public void restartScene()
   {
        Debug.Log("button is being pressed");
        PlayerPrefs.SetInt("score", currentScore);
        PlayerPrefs.SetInt("streak", streak);
        SceneManager.LoadScene(sceneNo);
   }
}

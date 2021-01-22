using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenBehavior : MonoBehaviour
{
    
   public void DisplayHighScore(double highscore)
    {
        this.transform.Find("HighscoreText").GetComponent<Text>().text = "Highscore: " + Mathf.Round((float)highscore);
    }
}

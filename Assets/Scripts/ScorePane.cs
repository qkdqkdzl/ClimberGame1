using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePane : MonoBehaviour
{
    string highScoreKey = "HighScore";
    public int Get_HighScore()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey);
        return highScore;
    }
    public void Set_HightScore(int cur_score)
    {
        if (cur_score > Get_HighScore())
        {
            PlayerPrefs.SetInt(highScoreKey, cur_score);
        }
    }   
}

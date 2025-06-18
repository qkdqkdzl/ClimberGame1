using UnityEngine;
using UnityEngine.Animations;

public class ScorePane : MonoBehaviour
{
    string highScoreKey = "HighScore";
    public int Get_HighScore()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey);
        return highScore;
    }
    public void Set_HightScore(int _score)
    {
        if (_score > Get_HighScore())
        {
            PlayerPrefs.SetInt(highScoreKey, _score);
        }
    }   
}
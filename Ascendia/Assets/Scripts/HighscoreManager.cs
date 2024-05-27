using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    private const string HighscoreKey = "Highscore";

    public void SaveHighscore(int score)
    {
        int currentHighscore = PlayerPrefs.GetInt(HighscoreKey, 0);
        if (score > currentHighscore)
        {
            PlayerPrefs.SetInt(HighscoreKey, score);
            PlayerPrefs.Save();
        }
    }

    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(HighscoreKey, 0);
    }
}

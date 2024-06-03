using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager
{
    public static void UpdateHighScores(int newScore)
    {
        List<int> highScores = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            highScores.Add(PlayerPrefs.GetInt("Highscore" + i, 0));
        }

        highScores.Add(newScore);
        highScores.Sort((a, b) => b.CompareTo(a));
        if (highScores.Count > 8)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        for (int i = 0; i < 8; i++)
        {
            PlayerPrefs.SetInt("Highscore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }
}

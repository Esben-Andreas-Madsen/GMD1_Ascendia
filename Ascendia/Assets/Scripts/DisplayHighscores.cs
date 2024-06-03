using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighscores : MonoBehaviour
{
    public TextMeshProUGUI[] highScoreTexts; // Assign these in the inspector

    private void Start()
    {
        LoadAndDisplayHighscores();
    }

    private void LoadAndDisplayHighscores()
    {
        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            int highScore = PlayerPrefs.GetInt("Highscore" + i, 0);
            highScoreTexts[i].text = "#" + (i + 1) + ": " + highScore.ToString();
        }
    }
}

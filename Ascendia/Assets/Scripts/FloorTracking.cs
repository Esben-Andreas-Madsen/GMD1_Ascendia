using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class FloorTracking : MonoBehaviour
//by Both
//Floor counter
//Quite scuffed we wanna avoid finding by tag
//The textmesh kept giving nullpointers
{
    private int currentFloor = 0;
    private int highscore = 0;
    private Transform playerTransform;
    private float previousPlayerY;
    private bool isInCollider = true;
    private const float minPlayerHeightIncrease = 5f;

    public TextMeshProUGUI floorText;
    public TextMeshProUGUI highscoreText;


    private void Start()
    {
        GameObject textMeshProObject = GameObject.FindGameObjectWithTag("FloorCounter");

        if (textMeshProObject != null)
        {
            floorText = textMeshProObject.GetComponent<TextMeshProUGUI>();
            floorText.text = "Floor: 0";
        }
        else
        {
            UnityEngine.Debug.LogError("TextMeshPro object not found.");
        }

        GameObject highscoreTextMeshProObject = GameObject.FindGameObjectWithTag("HighscoreCounter"); // Assuming you have a tag for the highscore
        if (highscoreTextMeshProObject != null)
        {
            highscoreText = highscoreTextMeshProObject.GetComponent<TextMeshProUGUI>();
            highscore = PlayerPrefs.GetInt("Highscore", 0);
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
        else
        {
            UnityEngine.Debug.LogError("Highscore TextMeshPro object not found.");
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            previousPlayerY = playerTransform.position.y;
        }
        else
        {
            UnityEngine.Debug.LogError("Player object not found.");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            isInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            isInCollider = false;
        }
    }

    private void Update()
    {
        if (playerTransform != null && !isInCollider)
        {
            float playerHeightIncrease = playerTransform.position.y - previousPlayerY;
            if (playerHeightIncrease >= minPlayerHeightIncrease)
            {
                currentFloor += Mathf.FloorToInt(playerHeightIncrease / minPlayerHeightIncrease);
                UnityEngine.Debug.Log("Current floor: " + currentFloor);
                previousPlayerY = playerTransform.position.y;

                floorText.text = "Floor: " + currentFloor.ToString();

                if (currentFloor > highscore)
                {
                    highscore = currentFloor;
                    highscoreText.text = "Highscore: " + highscore.ToString();
                    PlayerPrefs.SetInt("Highscore", highscore);
                    UnityEngine.Debug.Log("New highscore: " + highscore);
                }
            }
        }
    }
}

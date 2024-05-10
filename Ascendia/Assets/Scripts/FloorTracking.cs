using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FloorTracking : MonoBehaviour
{
    private int currentFloor = 0;
    private Transform playerTransform;
    private float previousPlayerY;

    private void Start()
    {
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
        UnityEngine.Debug.LogError("Collision detected");
        if (other.CompareTag("Platform") && playerTransform != null)
        {
            // Check if the player has moved up by at least 5 units
            float playerHeightIncrease = playerTransform.position.y - previousPlayerY;
            UnityEngine.Debug.LogError("Player height increase: " + playerHeightIncrease);
            UnityEngine.Debug.LogError("Current player Y: " + playerTransform.position.y);
            UnityEngine.Debug.LogError("Previous player Y: " + previousPlayerY);
            if (playerTransform.position.y - previousPlayerY >= 4f)
            {
                previousPlayerY = playerTransform.position.y;
                currentFloor++;
    
                UnityEngine.Debug.LogError("Current floor: " + currentFloor);

            }
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            previousPlayerY = playerTransform.position.y;
        }
    }
}


/* private void OnTriggerExit2D(Collider2D other)
 {
     if (other.CompareTag("Platform"))
     {
         currentFloor--;
         UnityEngine.Debug.Log("Current floor: " + currentFloor);
     }
 } */


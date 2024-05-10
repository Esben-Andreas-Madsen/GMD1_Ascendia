using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FloorTracking : MonoBehaviour
{
    private int currentFloor = 0;
    private Rigidbody2D playerRigidbody;
    private float previousPlayerY;

    private const float minPlayerHeightIncrease = 5f;
    private const float stationaryThreshold = 0.5f; // Threshhold for stationary trigger speed

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody2D>();
            previousPlayerY = player.transform.position.y;
        }
        else
        {
            UnityEngine.Debug.LogError("Player object not found.");
        }
    }

    private void Update()
    {
        if (playerRigidbody != null && Mathf.Abs(playerRigidbody.velocity.y) < stationaryThreshold)
        {
            float playerHeightIncrease = playerRigidbody.position.y - previousPlayerY;
            if (playerHeightIncrease >= minPlayerHeightIncrease)
            {
                currentFloor++;
                UnityEngine.Debug.Log("Current floor: " + currentFloor);
                previousPlayerY = playerRigidbody.position.y;
            }
        }
    }
}


/* using UnityEngine;

public class FloorTracking : MonoBehaviour
{
    private int currentFloor = 0;
    private Transform playerTransform;
    private float previousPlayerY;
    private bool isInCollider = true;

    private const float minPlayerHeightIncrease = 5f;

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
            }
        }
    }
} */
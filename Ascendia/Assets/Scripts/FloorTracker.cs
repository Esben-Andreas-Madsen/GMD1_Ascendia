using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FloorTracker : MonoBehaviour
{
    private int currentFloor = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            currentFloor++;
            UnityEngine.Debug.Log("Current floor: " + currentFloor);
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
}




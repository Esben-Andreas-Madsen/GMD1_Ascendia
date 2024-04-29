using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class FloorTracker : MonoBehaviour
{
    private int currentFloor = 0;
    public TextMeshProUGUI floorCountText;


    /* private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Platform"))
         {
             currentFloor++;
             UnityEngine.Debug.Log("Current floor: " + currentFloor);
         }
     } */

    private void OnTriggerExit2D(Collider2D other)
    {
        /* if (other.CompareTag("Platform"))
        {
            currentFloor--;
            UnityEngine.Debug.Log("Current floor: " + currentFloor);
        } */
        if (other.CompareTag("Platform"))
        {
            currentFloor++;
            UnityEngine.Debug.Log("Current floor: " + currentFloor);
        }
    } 
}




using UnityEngine;

public class CameraFollow : MonoBehaviour
    //by Esben
    //Follow the Players y-axis
{
    public Transform target; // Reference to the player's transform

    private void Update()
    {
        if (target != null)
        {
            // Get the current position of the camera
            Vector3 newPosition = transform.position;

            // Update only the y-coordinate to match the player's y-coordinate
            newPosition.y = target.position.y;

            // Apply the new position to the camera
            transform.position = newPosition;
        }
    }
}

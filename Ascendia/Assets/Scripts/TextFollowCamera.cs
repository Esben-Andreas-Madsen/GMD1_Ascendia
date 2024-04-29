using UnityEngine;
using TMPro;

public class TextFollowCamera : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    private TextMeshPro textMeshPro; // Reference to the TextMeshPro component

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>(); // Get the TextMeshPro component attached to this object
    }

    private void LateUpdate()
    {
        if (mainCamera != null && textMeshPro != null)
        {
            UnityEngine.Debug.Log("hey");
            // Get the current position of the text object
            Vector3 newPosition = mainCamera.transform.position;

            // Update only the y-coordinate to match the camera's y-coordinate
            newPosition.y = transform.position.y;

            // Apply the new position to the text object
            transform.position = newPosition;
        }
    }
}

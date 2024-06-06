using UnityEngine;

public class CameraFollow : MonoBehaviour
    //by Esben
    //Follow the Players y-axis
{
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            
            Vector3 newPosition = transform.position;

            
            newPosition.y = target.position.y;

            
            transform.position = newPosition;
        }
    }
}

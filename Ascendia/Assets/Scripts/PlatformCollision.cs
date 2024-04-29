using UnityEngine;

public class PlatformController : MonoBehaviour
{
    //by Esben
    //Player can land on top of platforms but and doesn't hit colliders that would impact momentum
    //Done by using 2 colliders, bottom is isTrigger to disable top that you stand on
    public Collider2D topCollider;
    public Collider2D bodyCollider;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the top collider when the player enters the body collider
            topCollider.enabled = false;
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the top collider when the player leaves the body collider
            topCollider.enabled = true;
        }
  
    }
}
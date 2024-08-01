using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destory connected object
        Destroy(other.gameObject); // Destory colliding object
    }
}

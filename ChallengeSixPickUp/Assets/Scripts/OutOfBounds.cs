using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    public float lowBound;
    void Update()
    {
        // Destroy object when out of low bound
        if (transform.position.z < lowBound) {
            Debug.Log("Game Over");
            Destroy(gameObject); }
    }
}
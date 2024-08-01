using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    public float lowBound;
    public float topBound;
    
    void Awake()
    {
        Time.timeScale = 1;
    }
    
    void Update()
    {
        // Boundery contraints
        // Destroy object when out of top bound
        if (transform.position.z > topBound) {
            Destroy(gameObject); }
        // Destroy object when out of low bound
        else if (transform.position.z < lowBound) {
            Debug.Log("Game Over");
            Destroy(gameObject);
            Time.timeScale = 0; }
    }
}

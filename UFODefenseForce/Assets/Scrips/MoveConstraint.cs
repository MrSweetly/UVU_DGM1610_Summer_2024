using UnityEngine;

public class MoveConstraint : MonoBehaviour
{
    public float xRange;
    void Update()
    {
        // Keep in movement range
        // Left X constraint
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // Right X constraint
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}

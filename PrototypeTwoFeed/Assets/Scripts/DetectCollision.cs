using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Detect colliding objects
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}

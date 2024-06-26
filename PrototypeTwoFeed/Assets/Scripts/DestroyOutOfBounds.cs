using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float bottomBound = -5;
    void Update()
    {
        // Game bounderies
        if (transform.position.z > topBound)
        {
            // Deletes object if goes past top bound
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound)
        {
            // Deletes object if goes past bottom bound
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}

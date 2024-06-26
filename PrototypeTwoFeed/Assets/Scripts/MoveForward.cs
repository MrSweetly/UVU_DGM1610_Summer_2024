using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    void Update()
    {
        // Object movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}

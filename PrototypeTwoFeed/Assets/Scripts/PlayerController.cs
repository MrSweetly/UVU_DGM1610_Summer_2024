using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float xRange = 10;
    public float speed = 10.0f;

    public GameObject projectilePrefab;
   void Update()
    {
        // Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));
        
        // Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch projectile from player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        
        // Keep player in bounds
        if (transform.position.x < -xRange)
        {
            // Stops player from moving past left bound
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
            // Stops player from moving past right bound
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}

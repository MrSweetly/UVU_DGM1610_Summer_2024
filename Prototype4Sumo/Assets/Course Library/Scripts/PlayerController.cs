using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;

    private float powerUpStrength = 15.0f;

    public GameObject PowerUpIndicator;

    public bool hasPowerUp;
    
    public float speed = 5.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * (speed * forwardInput));
        PowerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            PowerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());
        }
    }

    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        PowerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            
            Debug.Log("Collided with " + collision.gameObject.name + " with power-up set to " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}

using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed; 
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, -horizontalInput * rotationSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    void Update()
    {
        // Move game object forward
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}

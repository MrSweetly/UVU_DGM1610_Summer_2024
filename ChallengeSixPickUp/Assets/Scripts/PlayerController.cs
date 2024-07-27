using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    
    public float speed;
    public float gravity;
    public float jump;

    private float yHold;
    
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Works fine
    }

    void Update()
    {
        // Inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            yHold = jump; }
        
        // Gravity
        yHold -= gravity * Time.deltaTime;
        
        movement.y = yHold;

        // Movement
        var moveSpeed = movement * (speed * Time.deltaTime);
        controller.Move(moveSpeed);
    }
}
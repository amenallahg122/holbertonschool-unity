using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public CharacterController controller;
    public Camera mainCamera;
    public Vector3 startPosition;
    public float fallThreshold = -20f;
    
    private Vector3 velocity;
    private bool isGrounded;
    private float gravity = -9.81f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
    }
    
    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            ResetPlayerPosition();
            return;
        }
        
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;
        
        Vector3 move = forward * moveZ + right * moveX;
        controller.Move(move * moveSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    public void ResetPlayerPosition()
    {
        controller.enabled = false;
        transform.position = new Vector3(startPosition.x, startPosition.y + 10f, startPosition.z);
        velocity = Vector3.zero;
        controller.enabled = true;
    }
}

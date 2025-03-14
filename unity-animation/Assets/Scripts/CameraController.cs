using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    public Transform player;
    public float mouseSensitivity = 2f;
    public float distance = 5f;
    public float height = 2f;
    public float rotationSmoothness = 5f;
    public float maxFallDistance = 20f;
    public float playerRotationSpeed = 5f;
    
    private float rotationY = 0f;
    private float rotationX = 0f;
    private Transform playerTransform;
    private Vector3 startPosition;
    private PlayerMovement playerMovement;
    private Vector3 movementDirection;

    void Start() 
    {
        playerTransform = player;
        startPosition = transform.position;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update() 
    {
        if (player.position.y < -maxFallDistance) 
        {
            if (playerMovement != null) 
            {
                playerMovement.ResetPlayerPosition();
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movementDirection.magnitude > 0.1f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            player.rotation = Quaternion.Slerp(player.rotation, targetRotation, Time.deltaTime * playerRotationSpeed);
        }

        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (PlayerPrefs.GetInt("InvertY", 0) == 1) 
        {
            mouseYInput = -mouseYInput;
        }

        rotationX -= mouseYInput;
        rotationX = Mathf.Clamp(rotationX, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 direction = new Vector3(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, player.position + rotation * direction, Time.deltaTime * rotationSmoothness);
        transform.LookAt(playerTransform);
    }
}

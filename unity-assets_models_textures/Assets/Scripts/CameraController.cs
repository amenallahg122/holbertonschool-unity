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

    private float rotationY = 0f;
    private float rotationX = 0f;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = player;
    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX = Mathf.Clamp(rotationX, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 direction = new Vector3(0, height, -distance);

        transform.position = Vector3.Lerp(transform.position, player.position + rotation * direction, Time.deltaTime * rotationSmoothness);
        
        transform.LookAt(playerTransform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    public float trackingSpeed = 5f; // Speed at which the camera follows the player

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Desired position for the camera
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, trackingSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOfVision : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float visionRadius = 2.5f; // Radius of the vision circle

    void Update()
    {
        if (player != null)
        {
            // Update the position of the circle mask to follow the player
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(player.position);
            transform.position = playerScreenPosition;

            // Update the size of the vision circle based on the visionRadius
            GetComponent<RectTransform>().sizeDelta = new Vector2(visionRadius * 2, visionRadius * 2);
        }
    }
}


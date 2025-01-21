using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public variable to assign the Player GameObject via the Inspector
    public GameObject player;

    // Private variable to store the offset between the camera and the player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate and store the initial offset between the player and the camera
        if (player != null)
        {
            offset = transform.position - player.transform.position;
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned in the Inspector!");
        }
    }

    // LateUpdate is called after all Update functions have been processed
    void LateUpdate()
    {
        // Check if the player is assigned
        if (player != null)
        {
            // Update the camera's position relative to the player's position plus the offset
            transform.position = player.transform.position + offset;
        }
    }
}

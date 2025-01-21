using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene reloading

public class PlayerController : MonoBehaviour
{
    // Public variables
    public float speed = 5.0f;  // Movement speed of the player
    public int health = 5;      // Player's health
    public int startingHealth = 5; // Store the initial health value for reset
    public int score = 0;       // Player's score
    public int startingScore = 0; // Store the initial score value for reset

    // Start is called before the first frame update
    void Start()
    {
        // Initialize and log the score and health
        Debug.Log("Score: " + score);
        Debug.Log("Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player's health is 0
        if (health <= 0)
        {
            // Log Game Over message
            Debug.Log("Game Over!");

            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            // Reset the player's health and score to the original values
            health = startingHealth;
            score = startingScore;
        }

        // Create a Vector3 for movement
        Vector3 movement = Vector3.zero;

        // Check for key inputs to move on the X and Z axes
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement.z += 1; // Move forward
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement.z -= 1; // Move backward
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x -= 1; // Move left
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += 1; // Move right
        }

        // Normalize the movement vector to ensure consistent speed in diagonal directions
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Apply the movement to the player
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    // Trigger detection for interacting with pickups, traps, and the goal
    void OnTriggerEnter(Collider other)
    {
        // Check if the Player collided with a Pickup
        if (other.CompareTag("Pickup"))
        {
            // Increment the score
            score++;

            // Log the new score to the console
            Debug.Log("Score: " + score);

            // Disable or destroy the Coin (Pickup)
            other.gameObject.SetActive(false);
        }

        // Check if the Player collided with a Trap
        if (other.CompareTag("Trap"))
        {
            // Decrement the health
            health--;

            // Log the new health to the console
            Debug.Log("Health: " + health);
        }

        // Check if the Player collided with a Goal
        if (other.CompareTag("Goal"))
        {
            // Log "You win!" to the console
            Debug.Log("You win!");
        }
    }
}

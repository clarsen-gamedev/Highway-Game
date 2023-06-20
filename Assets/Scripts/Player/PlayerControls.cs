// Name: PlayerContols.cs
// Author: Connor Larsen
// Date: 06/17/2023
// Description: Script which controls the player's movements

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    #region Private Variables
    GameManager gameManager;    // Reference to the game manager
    float playerSpeed;          // The speed the player moves left and right
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        // Initialize Variables
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();  // Grab the Game Manager
        playerSpeed = 5f;                                                                       // Set the player speed
    }

    // Update is called once per frame
    void Update()
    {
        // Grab the input of the player
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        // Move the player based on player input
        transform.position += move * playerSpeed * Time.deltaTime;
    }

    // Check what the player collides with
    void OnTriggerEnter(Collider other)
    {
        // If an obstacle hits the player...
        if (other.tag == "Obstacle")
        {
            // Game over condition
            Debug.Log("Player hit obstacle, Game Over");
            Time.timeScale = 0f;    // Pause game time
        }

        // If the player avoids an obstacle
        else if (other.tag == "Score")
        {
            gameManager.score++;    // Add 1 to player score
        }
    }
    #endregion
}
// Name: ObstacleController.cs
// Author: Connor Larsen
// Date: 06/17/2023
// Description: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    #region Private Variables
    GameManager gameManager;    // Reference to the Game Manager game object
    Vector3 move;               // Direction the obstacle moves in

    float speed;    // Speed of the obstacle
    int spawnerID;  // Which spawner this obstacle spawned from
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();  // Grab the Game Manager
        move = new Vector3(0, 0, -1);                                                           // Set the direction the obstacle moves in
        speed = Random.Range(2, 5);                                                             // Picks a random speed between 1 and 5
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move * speed * Time.deltaTime;    // Move the obstacle down the path
    }

    // Check what the obstacle collides with
    void OnTriggerEnter(Collider other)
    {
        // If an obstacle hits the player...
        if (other.tag == "Despawner")
        {
            gameManager.spawner[spawnerID].isSpawning = false;  // Set isSpawning on spawner to false
            Destroy(gameObject);                                // Destroy this game object
        }
    }

    // Sets the spawner ID of the obstacle
    public void SetSpawnerID(int id)
    {
        spawnerID = id;
    }
    #endregion
}
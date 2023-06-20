// Name: ObstacleSpawner.cs
// Author: Connor Larsen
// Date: 06/17/2023
// Description: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    #region Public and Serialized Variables
    // Hidden
    [HideInInspector]public bool isSpawning;    // Check if the spawner has an active spawned entity

    // Visible
    [SerializeField] GameObject obstacle;       // Reference to the car obstacle prefabs
    [SerializeField] float minTime;             // Minimum wait time between spawns
    [SerializeField] float maxTime;             // Maximum wait time between spawns
    [SerializeField] int spawnerID;             // Reference to which spawner this is
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false; // Initialize isSpawning variable
    }

    // Update is called once per frame
    void Update()
    {
        // If spawner is not currently in use...
        if (isSpawning == false)
        {
            float timer = Random.Range(minTime, maxTime);   // Set a random timer
            Invoke("SpawnObstacle", timer);                 // Spawn an obstacle
            isSpawning = true;                              // Set isSpawning to true
        }
    }

    // Spawns an obstacle
    void SpawnObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);  // Spawn the obstacle
        newObstacle.GetComponent<ObstacleController>().SetSpawnerID(spawnerID);                                                                              // Match the obstacle with its spawner
    }
    #endregion
}
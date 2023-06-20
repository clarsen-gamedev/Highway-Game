// Name: GameManager.cs
// Author: Connor Larsen
// Date: 06/20/2023
// Description: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Public and Serialized Variables
    // Hidden
    [HideInInspector] public int score; // Keeps track of the player score

    // Visible
    [Header("UI")]
    [SerializeField] Text scoreUI;  // UI element for the score

    [Header("Game Systems")]
    public ObstacleSpawner[] spawner; // Reference to all spawners in the game
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI(); // Update the UI
    }

    // Update the UI
    void UpdateUI()
    {
        // Update the score
        scoreUI.text = "Score: " + score;
    }
}
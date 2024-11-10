using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager2 : MonoBehaviour
{
    public static TurnManager2 Instance;
    public bool playerTurn = true; // Player starts first
    public List<EnemySecond> enemies = new List<EnemySecond>(); // List of enemies
    public PlayerSecond player; // Reference to player script

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(TurnLoop());
    }

    IEnumerator TurnLoop()
    {
        while (true) // Loop indefinitely until game over
        {
            if (playerTurn)
            {
                // Start player turn
                yield return StartCoroutine(PlayerTurn());
                playerTurn = false; // Switch to enemy turn
            }
            else
            {
                // Start enemy turns
                yield return StartCoroutine(EnemyTurns());
                playerTurn = true; // Switch back to player turn
            }
        }
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("Player's turn");

        player.BeginTurn();

        // Wait until the player has made a move or attack
        while (!player.HasCompletedTurn)
        {
            yield return null; // Wait for player input
        }

        Debug.Log("Player has completed their turn");
    }

    IEnumerator EnemyTurns()
    {
        Debug.Log("Enemy turn");

        foreach (EnemySecond enemy in enemies)
        {
            if (enemy == null) continue; // Skip if the enemy is destroyed
            yield return StartCoroutine(enemy.TakeTurn());
        }

        Debug.Log("All enemies have completed their turn");
    }
}

using UnityEngine;
using System.Collections.Generic;

public class TurnManager2 : MonoBehaviour
{
    public enum TurnState { PlayerTurn, EnemyTurn }
    public TurnState currentTurn;

    public PlayerController player;  // Reference to the player script
    public List<EnemyController> enemies;  // List of enemy scripts

    private int currentEnemyIndex = 0;

    private void Start()
    {
        currentTurn = TurnState.PlayerTurn;  // Start with player's turn
        player.OnTurnComplete += EndPlayerTurn;  // Subscribe to player turn end
        foreach (var enemy in enemies)
        {
            enemy.OnTurnComplete += EndEnemyTurn;  // Subscribe to enemy turn ends
        }
    }

    private void EndPlayerTurn()
    {
        currentTurn = TurnState.EnemyTurn;
        currentEnemyIndex = 0;
        ProcessEnemyTurn();
    }

    private void EndEnemyTurn()
    {
        currentEnemyIndex++;
        if (currentEnemyIndex < enemies.Count)
        {
            ProcessEnemyTurn();  // Process next enemy
        }
        else
        {
            currentTurn = TurnState.PlayerTurn;  // Back to player turn
            player.StartTurn();  // Activate player turn
        }
    }

    private void ProcessEnemyTurn()
    {
        if (currentEnemyIndex < enemies.Count)
        {
            enemies[currentEnemyIndex].StartTurn();  // Trigger each enemy's turn in sequence
        }
    }
}

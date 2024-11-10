using UnityEngine;
using System.Collections.Generic;

public class EnemyCharacter : MonoBehaviour, ICharacter
{
    public bool IsPlayer => false;
    public int health = 50;
    public int defense = 3;

    private TurnManager2 turnManager;
    private PlayerCharacter playerTarget;
    private List<IAttack> attacks = new List<IAttack>();

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager2>();
        playerTarget = FindObjectOfType<PlayerCharacter>();

        // Add multiple attacks to the enemy
        attacks.Add(new SwordAttack(8));
        attacks.Add(new RangedAttack(6));
    }

    public void StartTurn()
    {
        Debug.Log("Enemy's turn starts.");
        TakeAction();
    }

    public void TakeAction()
    {
        if (playerTarget != null)
        {
            // Choose a random attack for the enemy
            int randomIndex = Random.Range(0, attacks.Count);
            attacks[randomIndex].Execute(playerTarget);
            
            // After completing the action, end the enemy's turn
            EndEnemyTurn();
        }
    }

    public void EndEnemyTurn()
    {
        // Call the TurnManager2's EndTurn method to switch to the next character
        turnManager.EndTurn();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Enemy takes {amount} damage. Remaining health: {health}");
    }

    public int Defense => defense;
}

using UnityEngine;
using System.Collections.Generic;

public class PlayerCharacter : MonoBehaviour, ICharacter
{
    public bool IsPlayer => true;
    public int health = 100;
    public int defense = 5;

    private TurnManager2 turnManager;
    private List<IAttack> attacks = new List<IAttack>();

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager2>();

        // Add some attacks to the player's list
        attacks.Add(new SwordAttack(10));
        attacks.Add(new AOEAttack(12, 3));
    }

    public void StartTurn()
    {
        Debug.Log("Player's turn starts.");
        // Here, you could prompt the player to select an attack
    }

    public void TakeAction()
    {
        // Implement logic for player action here
        // For example, this could be selecting and using an attack from the list
        Debug.Log("Player is taking an action.");
    }

    public void UseAttack(int attackIndex, ICharacter target)
    {
        if (attackIndex >= 0 && attackIndex < attacks.Count)
        {
            var attack = attacks[attackIndex];
            attack.Execute(target);
            EndPlayerTurn();
        }
        else
        {
            Debug.Log("Invalid attack choice.");
        }
    }

    public void EndPlayerTurn()
    {
        turnManager.PlayerEndsTurn();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Player takes {amount} damage. Remaining health: {health}");
    }

    public int Defense => defense;
}

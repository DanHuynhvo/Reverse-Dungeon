using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager2 : MonoBehaviour
{
    // List to hold all characters in the turn order
    public List<ICharacter> turnOrder = new List<ICharacter>();
    
    public int currentTurnIndex = 0;
    public bool isPlayerTurn = true;

    void Start()
    {
        // Initialize turn order and start the first turn
        InitializeTurnOrder();
        StartTurn();
    }

    void InitializeTurnOrder()
    {
        // Populate the turnOrder list with player(s) and enemy characters
        // Assuming you have scripts for PlayerCharacter and EnemyCharacter that implement ICharacter
        foreach (var character in FindObjectsOfType<PlayerCharacter>())
        {
            turnOrder.Add(character);
        }
        
        foreach (var character in FindObjectsOfType<EnemyCharacter>())
        {
            turnOrder.Add(character);
        }
        
        // Sort turn order if needed, e.g., by initiative or speed
        // turnOrder.Sort((a, b) => a.Initiative.CompareTo(b.Initiative));
    }

    void StartTurn()
    {
        if (turnOrder.Count == 0) return;

        ICharacter currentCharacter = turnOrder[currentTurnIndex];
        currentCharacter.StartTurn();

        if (currentCharacter.IsPlayer)
        {
            // Wait for player action
        }
        else
        {
            // If enemy, execute AI logic automatically
            StartCoroutine(EnemyTurn(currentCharacter));
        }
    }

   public void EndTurn()
{
    // Move to the next turn
    currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;

    // Log the index to track progression
    Debug.Log("Turn ended. Next character index: " + currentTurnIndex);

    // Check if a new round has started
    if (currentTurnIndex == 0)
    {
        Debug.Log("New round started");
    }

    StartTurn();
}


    private IEnumerator EnemyTurn(ICharacter enemy)
    {
        yield return new WaitForSeconds(1); // Optional delay for enemy action
        enemy.TakeAction(); // Implement enemy AI behavior in TakeAction()
        EndTurn();
    }

 



     public void PlayerEndsTurn()
    {
        EndTurn(); // End the player's turn and proceed to the next character in the turn order
    }
}
 
/*  
    A queue or list of characters (players and enemies).
    A method to start the turn cycle.
    Logic to switch between players and enemies after each turn.
*/





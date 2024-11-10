using UnityEngine;
using System.Collections;


public class PlayerSecond : MonoBehaviour
{
    public bool HasCompletedTurn { get; private set; }

    public int attackOption;  // Attack option selected
    public int moveOption;
    
  

    
 void Update()
    {

       
        
        if (!HasCompletedTurn)
        {
            // Read input for movement or attack only when it's the player's turn
            if (IsMove()) // If movement input detected
            {
                Move();
                EndTurn();
            }
            else if (IsAttack()) // Check if the player initiated an attack
            {
                Attack();
                EndTurn();
            }
        }
    }
    
    
    public void BeginTurn()
    {
        HasCompletedTurn = false;
        Debug.Log("Player's turn has started. Waiting for input...");
    }


    private void Move()
    {
        // Implement move logic here
        Debug.Log("Player moved");
    }

    private void Attack()
    {
        // Implement attack logic here
        Debug.Log("Player attacked");
    }

    public void EndTurn()
    {
        HasCompletedTurn = true;
    }

    // Call EndTurn() after player completes a move or attack


    public bool IsAttack()
    {
        // Using the new Input System for handling attack options
        if (Input.GetKeyDown(KeyCode.Alpha1)) { attackOption = 1; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { attackOption = 2; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { attackOption = 3; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { attackOption = 4; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { attackOption = 5; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) { attackOption = 6; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) { attackOption = 7; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha8)) { attackOption = 8; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha9)) { attackOption = 9; return true; }
        else if (Input.GetKeyDown(KeyCode.Alpha0)) { attackOption = 0; return true; }

        return false;  // No key pressed
    }

    public bool IsMove(){
    if(Input.GetKeyDown(KeyCode.W)){moveOption = 1; return true;}
    else if(Input.GetKeyDown(KeyCode.D)){moveOption = 2; return true;}
    else if(Input.GetKeyDown(KeyCode.S)){moveOption = 3; return true;}
    else if(Input.GetKeyDown(KeyCode.A)){moveOption = 3; return true;}
    return false; 
    }


}




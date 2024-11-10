using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurn : MonoBehaviour
{
    public bool myTurn = false;  // Track if it’s the player's turn
    public InputAction playerMovement;  // Player movement input action
    public PlayerMovement movementScript;  // Player movement script reference
    public Vector2 moveDirection = Vector2.zero;  // Current movement direction
    public Vector2 zeroDirection = Vector2.zero;  // Zero movement direction
    public int attackOption;  // Attack option selected

    public AttackScript attackScript;  // Attack script reference

    private void OnEnable()
    {
        // Enable the player movement input action when the object is enabled
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        // Disable the player movement input action when the object is disabled
        playerMovement.Disable();
    }

    // Coroutine that starts the player’s turn
    public IEnumerator StartPlayerTurn()
    {
        if (myTurn)
        {
            // Debug log for turn start
            Debug.Log("Player's Turn Started");
            yield return StartCoroutine(Decisions()); // Start making decisions during the turn
        }
    }

    // Coroutine to handle player’s decisions (movement/attack)
    public IEnumerator Decisions()
    {
        bool buttonPress = false;
          // Get the movement direction from the input system

        while (moveDirection == zeroDirection && !buttonPress)  // Loop until movement or button press occurs
        {
            moveDirection = playerMovement.ReadValue<Vector2>();

            // Check if a movement input is provided
            if (moveDirection != zeroDirection)
            {
                Debug.Log("Movement Chosen");
                movementScript.playerMoving(moveDirection);  // Move the player based on the input
            }

            // Check for attack input
            if (IsAttack())
            {
                // If attack button is pressed, start the attack process
                Debug.Log("Attack chosen");
                buttonPress = true;  // Set the button press flag to true
                StartCoroutine(attackScript.chosenAttack(attackOption));  // Perform the attack
            }

            // Wait for the next frame
            yield return null;
        }

        // Optionally, after the decision is made, you could perform other actions here
        GameEvents.current.PlayerTurnEnd();
        Debug.Log("Player's turn finished");
    }

    // Check if the player pressed any attack key (1-9, 0)
    public bool IsAttack()
    {
        // Using the new Input System for handling attack options
        if (Keyboard.current.digit1Key.wasPressedThisFrame) { attackOption = 1; return true; }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame) { attackOption = 2; return true; }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame) { attackOption = 3; return true; }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame) { attackOption = 4; return true; }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame) { attackOption = 5; return true; }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame) { attackOption = 6; return true; }
        else if (Keyboard.current.digit7Key.wasPressedThisFrame) { attackOption = 7; return true; }
        else if (Keyboard.current.digit8Key.wasPressedThisFrame) { attackOption = 8; return true; }
        else if (Keyboard.current.digit9Key.wasPressedThisFrame) { attackOption = 9; return true; }
        else if (Keyboard.current.digit0Key.wasPressedThisFrame) { attackOption = 0; return true; }

        return false;  // No key pressed
    }
}

/*using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerTurn : MonoBehaviour
{
    public bool myTurn = false;
    public InputAction playerMovement;
    public PlayerMovement movementScript;
    public Vector2 moveDirection = Vector2.zero;
    public Vector2 zeroDirection = Vector2.zero;
    public int attackOption;

    public AttackScript attackScript;

    public void Awake()
    {

    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    public IEnumerator StartPlayerTurn()
    {
        if (myTurn == true)
        {
            //Debug.Log("Start");
            StartCoroutine(Decisions());


        }

        yield return null;
    }

    public IEnumerator Decisions()
    {
        bool buttonPress = false;
        moveDirection = playerMovement.ReadValue<Vector2>();

        while (moveDirection == zeroDirection || buttonPress == false)
        {
            
            if (moveDirection != zeroDirection)
            {
                movementScript.playerMoving(moveDirection);
            }

            else if (IsAttack())
            {
                Debug.Log("Help Me");
                buttonPress = true;
                StartCoroutine(attackScript.chosenAttack(attackOption));
            }

            yield return new WaitForEndOfFrame();
        }





        yield return null;
    }


    public bool IsAttack()
{
    // Check if any of the number keys are pressed
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        attackOption = 1;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        attackOption = 2;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
        attackOption = 3;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4))
    {
        attackOption = 4;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha5))
    {
        attackOption = 5;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha6))
    {
        attackOption = 6;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha7))
    {
        attackOption = 7;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha8))
    {
        attackOption = 8;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha9))
    {
        attackOption = 9;
        return true;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha0))
    {
        attackOption = 0;
        return true;
    }
    else
    {
        return false; // No key pressed
    }
}

}*/

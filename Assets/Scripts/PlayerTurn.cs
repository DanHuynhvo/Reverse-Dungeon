using System.Collections;
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
            StartCoroutine(Decisions());


        }

        yield return new WaitForSeconds(2f);
    }

    public IEnumerator Decisions()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();


        if (moveDirection != zeroDirection)
        {
            movementScript.playerMoving(moveDirection);
        }

        else if (IsAttack())
        {

            StartCoroutine(attackScript.chosenAttack(attackOption));
        }

        yield return new WaitForSeconds(2f);
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

}

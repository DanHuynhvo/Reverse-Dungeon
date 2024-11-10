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
    }

    public IEnumerator Decisions()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
       

        if (moveDirection != zeroDirection)
        {
            movementScript.playerMoving(moveDirection);
        }

        else if (IsAttack) { 



        }
    }

    public bool IsAttack()
    {
        // Check if the "1" key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Alpha3)||Input.GetKeyDown(KeyCode.Alpha4)||Input.GetKeyDown(KeyCode.Alpha5)||Input.GetKeyDown(KeyCode.Alpha6)||Input.GetKeyDown(KeyCode.Alpha7)||Input.GetKeyDown(KeyCode.Alpha8)||Input.GetKeyDown(KeyCode.Alpha9)||Input.GetKeyDown(KeyCode.Alpha0))
        {

        return true  

        }else {

        return false

      }
    }
}

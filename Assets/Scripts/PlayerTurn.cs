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

    /*public IEnumerator StartPlayerTurn()
    {
        if (myTurn == true)
        {
            StartCoroutine(Decisions());


        }
    }

    public IEnumerator Decisions()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        playerAttack = InputAction.Player.Skill;

        if (moveDirection != zeroDirection)
        {
            movementScript.playerMoving(moveDirection);
        }

        else if (playerAttack.triggered) { }
    }*/

    void Update()
    {
        // Check if the "1" key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("The '1' key was pressed!");
        }
    }
}

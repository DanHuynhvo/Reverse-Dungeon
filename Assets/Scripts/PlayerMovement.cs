using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public bool playerActing = false;
    public Transform movePoint;
    public InputAction playerMovement;
    public Vector3 moveDirection = Vector3.zero;
    public LayerMask wall, enemy;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }
    private void Start()
    {
        movePoint.parent = null;
    }

    public void playerMoving(Vector2 md)
    {
        // Get player input for movement
        //moveDirection = playerMovement.ReadValue<Vector2>();

        // Check if player is close enough to the target to start moving
        if (Vector2.Distance(transform.position, movePoint.position) <= .005f && (moveDirection.x != 0 || moveDirection.y != 0))
        {
            // Snap player to the nearest integer position if needed (optional)
            Vector3 currentPosition = transform.position;
            Vector3 snappedPosition = new Vector3(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y), Mathf.Round(currentPosition.z));
            transform.position = snappedPosition;

            // Remove diagonal movement by ensuring only one axis is active at a time
            if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
            {
                moveDirection.y = 0;  // Only allow horizontal movement
            }
            else
            {
                moveDirection.x = 0;  // Only allow vertical movement
            }

            // Normalize and apply the movement towards the target point
            movePoint.position += Vector3.Normalize(moveDirection);
            playerActing = true;  // Indicate that the player is moving
        }

        // Only move player towards the target if they are still acting (i.e., moving)
        if (playerActing)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        // Check for obstacles before moving
        if (!Physics2D.OverlapCircle((Vector2)movePoint.position, 0.1f, wall) && !Physics2D.OverlapCircle((Vector2)movePoint.position, 0.1f, enemy))
        {
            // Move the player smoothly towards the target position
            transform.position = Vector2.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            // Check if player has reached the target position
            if (Vector2.Distance(transform.position, movePoint.position) <= 0.005f)
            {
                // Player has finished moving, call PlayerTurnEnd()
                //GameEvents.current.PlayerTurnEnd();

                // Reset playerActing to false, as movement is complete
                playerActing = false;
            }
        }
        else
        {
            // If there's an obstacle, stop the player at the current position
            movePoint.position = transform.position;
        }

    }
}

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
    public Transform movePoint;
    public InputAction playerMovement;
    public Vector3 moveDirection = Vector3.zero;
    public LayerMask wall;

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

    public void MovePlayer(Transform MovePoint)
    {
        // Move towards the target position
        if (!Physics2D.OverlapCircle((Vector2)movePoint.position, .1f, wall))
        {
            transform.position = Vector2.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Wall");
            movePoint.position = transform.position;
        }
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, movePoint.position) <= .005f)
        {
            // Get player input for movement
            moveDirection = playerMovement.ReadValue<Vector2>();

            // Remove diagonal movement by ensuring only one axis is active at a time
            if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
            {
                moveDirection.y = 0;  // Only allow horizontal movement
            }
            else
            {
                moveDirection.x = 0;  // Only allow vertical movement
            }

            // Normalize and apply the movement
            movePoint.position += Vector3.Normalize(moveDirection);
            GameEvents.current.PlayerTurnEnd();
        }

        MovePlayer(movePoint);
    }
}

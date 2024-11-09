using UnityEngine;


public class CharacterController : MonoBehaviour
{


public float moveSpeed = 5f;
public LayerMask WallLayer;
private float gridsize = 1f;
private Vector2 targetPosition;
private bool canMove = false;
private bool isMoving = false;
private HealthScript HS;
public event System.Action OnTurnEnded;


    void Awake(){

        HS = GameObject.Find("Player").GetComponent<HealthScript>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

      if(canMove || !isMoving){

        if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)){
            SetTargetPosition(Vector2.up);
            //Moving Up
            EndTurn();

        }else if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)){
            SetTargetPosition(Vector2.down);
            //Moving Down
            EndTurn();
        }else if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)){
            SetTargetPosition(Vector2.right);
            //Moving Right
            EndTurn();
        }else if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)){
            SetTargetPosition(Vector2.left);
            //Moving Left
        }else if(Input.GetKeyDown(KeyCode.Y)){

            HS.TakeDamage(3);
            EndTurn();
        }else if(Input.GetKeyDown(KeyCode.U)){

            HS.Heal(2);
            EndTurn();
        }
      }

      if(isMoving){

        transform.position = targetPosition; // Snap to the target position
        isMoving = false;
        EndTurn();
      }

    }

    void SetTargetPosition(Vector2 direction){

        
       Vector2 newTargetPosition = (Vector2)transform.position + direction * gridsize;

        // Check if the new position is blocked by a wall
        if (!Physics2D.OverlapCircle(newTargetPosition, 0.1f, WallLayer))
        {
            targetPosition = newTargetPosition;
            isMoving = true; // Enable movement to the target position
        }
    }

    public void EnableMovement(){
        canMove = true;
    }
    
    void EndTurn(){

        canMove = false;
        OnTurnEnded?.Invoke();
    }
}

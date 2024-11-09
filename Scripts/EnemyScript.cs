using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    public string Name;
    public int MaxHealth;
    public float Move;
    public float DetectionRange;
    public LayerMask WallLayer;


    private int CurrentHealth;
    private Transform player;
    private bool isDead;
    private bool isTurn = false;

    private IAttack attackBehavior;
    public event System.Action OnTurnEnded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
        player = GameObject.FindWithTag("Player").transform;

        attackBehavior = GetComponent<IAttack>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(isTurn && !isDead){
            CheckForPlayer();
        }
    }

   void CheckForPlayer(){

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= DetectionRange){
          
            MoveTowardsPlayer();

                if(attackBehavior != null && distanceToPlayer <= attackBehavior.Range){

                    PerformAttack();
                }
        }
        EndTurn();
   }

   void MoveTowardsPlayer(){

   int movesRemaining = (int)Move; // Number of moves the enemy can make this turn

    while (movesRemaining > 0)
    {
        // Calculate the distance in both X and Y directions
        float distanceX = player.position.x - transform.position.x;
        float distanceY = player.position.y - transform.position.y;

        Vector2 primaryDirection;
        Vector2 secondaryDirection;

        // Determine the primary and secondary directions based on which axis has the greater distance
        if (Mathf.Abs(distanceX) > Mathf.Abs(distanceY))
        {
            primaryDirection = distanceX > 0 ? Vector2.right : Vector2.left;
            secondaryDirection = distanceY > 0 ? Vector2.up : Vector2.down;
        }
        else
        {
            primaryDirection = distanceY > 0 ? Vector2.up : Vector2.down;
            secondaryDirection = distanceX > 0 ? Vector2.right : Vector2.left;
        }

        // Calculate target positions for both primary and secondary directions
        Vector2 primaryTargetPosition = (Vector2)transform.position + primaryDirection;
        Vector2 secondaryTargetPosition = (Vector2)transform.position + secondaryDirection;

        // Try moving in the primary direction first
        if (!Physics2D.OverlapCircle(primaryTargetPosition, 0.1f, WallLayer))
        {
            // Move in the primary direction if it's not blocked
            transform.position = primaryTargetPosition;
        }
        // If primary direction is blocked, try the secondary direction
        else if (!Physics2D.OverlapCircle(secondaryTargetPosition, 0.1f, WallLayer))
        {
            // Move in the secondary direction if the primary is blocked
            transform.position = secondaryTargetPosition;
        }
        else
        {
            // Both directions are blocked, exit the movement loop for this turn
            Debug.Log($"{Name} is blocked and cannot move closer to the player.");
            break;
        }

        // Decrease the number of moves remaining
        movesRemaining--;
    }
   }
    

   void PerformAttack(){
        if(attackBehavior != null){

            attackBehavior.Attack(player);
            Debug.Log($"{Name}  Performs Attack");
        }else{

            Debug.Log($"{Name}  Has No Attacks");
        }
   }
    



   public void TakeDamage(int amountDamage){

    CurrentHealth -= amountDamage;
    Debug.Log($"{Name} Takes {amountDamage} Damage");
        
    if(CurrentHealth <= 0){
        Die();
    }

   }

   void Die(){

    isDead = true;
    Debug.Log($"{Name} Has Died");

   }


 public void EnableMovement(){
        isTurn = true;
    }

   void EndTurn()
   {

    isTurn = false;
    OnTurnEnded?.Invoke();
   }
}

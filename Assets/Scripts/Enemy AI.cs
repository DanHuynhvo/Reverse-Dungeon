using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector2 north = new Vector2(0, 1);  // Vector2 for north
    public Vector2 south = new Vector2(0, -1); // Vector2 for south
    public Vector2 east = new Vector2(1, 0);   // Vector2 for east
    public Vector2 west = new Vector2(-1, 0);  // Vector2 for west
    public Vector2[] direction = new Vector2[4];  // Array of directions
    public Vector2[] neighbors = new Vector2[4];  // Array of neighbors
    public float[] playerDistance = new float[] { 0f, 0f, 0f, 0f };  // Array for storing distances

    private void Start()
    {
        GameEvents.current.onPlayerTurnEnd += MoveEnemy;
        direction[0] = north;
        direction[1] = south;
        direction[2] = east;
        direction[3] = west;
    }

    private void GetNeighbors()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            // Update the position by adding the direction (ignoring the z-component)
            neighbors[i] = new Vector2(transform.position.x, transform.position.y) + direction[i];
            Debug.Log($"Neighbor {i}: {neighbors[i]}");
        }
    }

    private void GetDistanceFromPlayer()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            // Calculate the 2D distance (ignoring z-axis)
            playerDistance[i] = Vector2.Distance(neighbors[i], new Vector2(Player.instance.gameObject.transform.position.x, Player.instance.gameObject.transform.position.y));
            Debug.Log($"Distance to neighbor {i}: {playerDistance[i]}");
        }
    }

    private void MoveEnemy()
    {
        GetNeighbors();
        GetDistanceFromPlayer();
    }
}

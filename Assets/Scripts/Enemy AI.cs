using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector3 north = new Vector3(0, 1, 0);
    public Vector3 south = new Vector3(0, -1, 0);
    public Vector3 east = new Vector3(1, 0, 0);
    public Vector3 west = new Vector3(-1, 0, 0);
    public Vector3[] direction = new Vector3[4];
    public Vector3[] neighbors = new Vector3[4];
    public float[] playerDistance = new float[] {0f, 0f, 0f, 0f};

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
            neighbors[i] = transform.position + direction[i];
            //Debug.Log(neighbors[i]);
        }
    }

    private void GetDistanceFromPlayer()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            playerDistance[i] = Vector3.Distance(neighbors[i], Player.instance.gameObject.transform.position);
            Debug.Log(playerDistance[i]);
        }
    }

    private void MoveEnemy()
    {
        GetNeighbors();
        GetDistanceFromPlayer();
    }
}

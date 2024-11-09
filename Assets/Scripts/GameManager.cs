using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] floorEnemies;

    public void Start()
    {
        GameEvents.current.onPlayerTurnEnd += EnemyTurns;
    }

    public void EnemyTurns()
    {
        for (int i = 0; i < floorEnemies.Length; i++)
        {
            floorEnemies[i].gameObject.GetComponent<EnemyAI>().MoveEnemy();
        }
    }
}

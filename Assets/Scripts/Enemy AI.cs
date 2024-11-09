using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onPlayerTurnEnd += MoveEnemy;
    }

    private void MoveEnemy()
    {
        Debug.Log("Fucko Butthole");
    }
}

using UnityEngine;
using System.Collections;

public class EnemySecond : MonoBehaviour
{
    public IEnumerator TakeTurn()
    {
        // Add logic for the enemy to move or attack here

        yield return new WaitForSeconds(1f); // Simulate enemy turn time
        Debug.Log("Enemy has completed turn");
    }
}


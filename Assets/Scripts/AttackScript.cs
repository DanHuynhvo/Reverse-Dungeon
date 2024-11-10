using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public List<Attack> playerAttacks = new List<Attack>();
    public Collider2D[] enemiesInRange;
    public List<GameObject> listOfEnemies = new List<GameObject>();
    public Transform player;
    public Vector2 range = Vector2.zero;
    public LayerMask enemy;
    GameObject attackChosen;



    public IEnumerator chosenAttack(int option)
    {
        attackChosen = playerAttacks[option -1].gameObject;
        range = playerAttacks[option - 1].range;

        //Instantiate(attackChosen);
        enemiesInRange = Physics2D.OverlapBoxAll(player.position, range, 0, enemy);

        for(int i = 0; i < enemiesInRange.Length; i++)
        {
            listOfEnemies.Add(enemiesInRange[i].gameObject);
            listOfEnemies[i].gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(2f);

    }
}

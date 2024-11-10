using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public List<Attack> playerAttacks = new List<Attack>();
    public List<GameObject> enemiesInRange = new List<GameObject>();
    public Transform player;
    public Vector2 range = Vector2.zero;
    public LayerMask enemy;
    GameObject attackChosen;



    public void chosenAttack(int option)
    {
        attackChosen = playerAttacks[option].gameObject;
        range = playerAttacks[option].range;

        //Instantiate(attackChosen);
        enemiesInRange = new List<GameObject>();
        {

        };
        Physics2D.OverlapBoxAll(player.position, range, 0, enemy);



    }
}
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<GameObject> turns = new List<GameObject>();
    public PlayerTurn playerTurn;
    //public GameObject player;
    public bool floorRunning = true;
    public int currentTurn = 0;

    public void Start()
    {
        //turns.Add(Player.instance.gameObject);
        while (floorRunning == true)
        {
            if (currentTurn == 0)
            {
                Debug.Log("Starting Player");
                StartCoroutine(playerTurn.StartPlayerTurn());
            }
        }
    }
}

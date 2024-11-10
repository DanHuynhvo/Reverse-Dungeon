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
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
            if (currentTurn == 0)
            {
                StartCoroutine(playerTurn.StartPlayerTurn());
            }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{


    public CharacterController player;

    public List<EnemyScript> enemies;

    private int currentTurnIndex = 0;

    private bool isPlayerTurn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlayerTurn = true;

        player.OnTurnEnded += EndPlayerTurn;

        foreach (EnemyScript enemy in enemies){

            enemy.OnTurnEnded += EndEnemyTurn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerTurn){
            player.EnableMovement();
        }
    }

    void EndPlayerTurn(){

        isPlayerTurn = false;

        currentTurnIndex = 0;
        ProcessEnemyTurn();
    }

    void ProcessEnemyTurn(){
        if(currentTurnIndex < enemies.Count){
            
            enemies[currentTurnIndex].EnableMovement();

        }else{

            isPlayerTurn = true;
        }
    }

    void EndEnemyTurn(){

        currentTurnIndex++;
        ProcessEnemyTurn();
    }
}

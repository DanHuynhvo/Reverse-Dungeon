using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagment;
public class BlackjackManagment : MonoBehaviour
{
    public Text playerScoreText;
    public Deck deck;
    public int playerScore;
    public int discardAllowed = 0;
    
    [SerializeField]
    public List<Card> playerHand;

    void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        deck = new Deck();
        playerHand = new List<Card>();
        playerScore = 0;
        DealInitialCards();
    }

    private void DealInitialCards()
    {
        playerHand.Add(deck.DrawCard());
        playerHand.Add(deck.DrawCard());
        LogPlayerHand();
        UpdateScores();
    }

    private void UpdateScores()
    {
        playerScore = CalculateScore(playerHand);
        playerScoreText.text = "Player Score: " + playerScore;
    }

    private int CalculateScore(List<Card> hand)
    {
        int score = 0;
        int aceCount = 0;

        foreach (Card card in hand)
        {
            if (card.Value == 1) aceCount++;
            score += card.Value;
        }

        // Adjust for Aces (count 11 if it helps to reach 21 without busting)
        while (score <= 11 && aceCount > 0)
        {
            score += 10;
            aceCount--;
        }

        return score;
    }

    public void OnHit()
    {
        playerHand.Add(deck.DrawCard());
        LogPlayerHand();
        UpdateScores();
        if (playerScore > 21)
        {
            Debug.Log("Player Bust! Dealer Wins.");
            

        }
    }

    private void CheckForWinner()
    {
        if (playerScore > 21){
            
        }else{

        }
    }

     public void OnStand()
    {
        UpdateScores();
        CheckForWinner();
    }

    public void LogPlayerHand()
{
    string handDescription = "Player's Hand:\n";
    foreach (Card card in playerHand)
    {
        handDescription += $"{card.Name} (Value: {card.Value})\n";
    }
    Debug.Log(handDescription);
}
}

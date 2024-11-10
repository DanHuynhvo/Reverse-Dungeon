using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class BlackjackManagment : MonoBehaviour
{
    public Text playerScoreText;
    public Text dealerScoreText;
    public Deck deck;
    private int playerScore;
    private int dealerScore;
    private List<Card> playerHand;
    private List<Card> dealerHand;

    void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        deck = new Deck();
        playerHand = new List<Card>();
        dealerHand = new List<Card>();
        playerScore = 0;
        dealerScore = 0;
        DealInitialCards();
    }

    private void DealInitialCards()
    {
        playerHand.Add(deck.DrawCard());
        playerHand.Add(deck.DrawCard());
        dealerHand.Add(deck.DrawCard());
        dealerHand.Add(deck.DrawCard());

        UpdateScores();
    }

    private void UpdateScores()
    {
        playerScore = CalculateScore(playerHand);
        dealerScore = CalculateScore(dealerHand);
        playerScoreText.text = "Player Score: " + playerScore;
        dealerScoreText.text = "Dealer Score: " + dealerScore;
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
}

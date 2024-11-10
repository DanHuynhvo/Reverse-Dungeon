using UnityEngine;
using System.Collections.Generic;


public class Deck
{
    public List<Card> cards;
    public Sprite[] cardSprites; // Drag all card sprites into this array in the Inspector


    public Deck()
    {
        cards = new List<Card>();
        InitializeDeck();
        Shuffle();
    }

    public void InitializeDeck()
    {
        // Add 52 cards with four suits and values 1-11
        // Example: cards.Add(new Card { Suit = "Hearts", Value = 10, Name = "10 of Hearts" });
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 }; // Values for each rank (10 for face cards, 11 for Ace)

        foreach (string suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                Card card = new Card
                {
                    Suit = suit,
                    Value = values[i],
                    Name = $"{ranks[i]} of {suit}",
                    CardSprite = GetCardSprite(suit, ranks[i]) // Get the appropriate sprite for the card

                };
                cards.Add(card);
            }
        }
    }

    private Sprite GetCardSprite(string suit, string rank)
    {
        // Assuming you have named each sprite as "2 of Hearts", "Ace of Spades", etc.
        foreach (Sprite sprite in cardSprites)
        {
            if (sprite.name == $"{rank} of {suit}")
                return sprite;
        }
        return null;
    }

    public void Shuffle()
    {
        // Implement shuffle logic here
          for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

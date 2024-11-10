using UnityEngine;
using System.Collections.Generic;


public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        // Add 52 cards with four suits and values 1-11
        // Example: cards.Add(new Card { Suit = "Hearts", Value = 10, Name = "10 of Hearts" });
    }

    public void Shuffle()
    {
        // Implement shuffle logic here
    }

    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

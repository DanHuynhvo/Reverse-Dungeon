using UnityEngine;


public class Card
{
    public string Suit { get; set; }
    public int Value { get; set; } // Ace = 1, Jack/Queen/King = 10
    public string Name { get; set; } // e.g., "Ace of Spades"
    public GameObject CardPrefab { get; set; } // Reference to the card prefab
}


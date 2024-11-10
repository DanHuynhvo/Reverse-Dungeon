using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject[] cardPrefabs; // Assign all card prefabs in the Inspector
    private Dictionary<string, GameObject> cardPrefabDict;
    private List<Card> cards;

    void Start()
    {
        cards = new List<Card>(); // Ensure `cards` is initialized
        InitializeDeck();
        Shuffle();
    }

    public void InitializeDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        // Create dictionary for card prefabs by name
        cardPrefabDict = new Dictionary<string, GameObject>();

        if (cardPrefabs == null || cardPrefabs.Length == 0)
        {
            Debug.LogError("Card Prefabs not assigned in the Inspector!");
            return;
        }

        foreach (GameObject prefab in cardPrefabs)
        {
            if (prefab == null)
            {
                Debug.LogWarning("Null prefab found in cardPrefabs array.");
                continue;
            }

            cardPrefabDict[prefab.name] = prefab;
        }

        // Populate the deck with cards
        foreach (string suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                string cardName = $"{ranks[i]} of {suit}";

                Card card = new Card
                {
                    Suit = suit,
                    Value = values[i],
                    Name = cardName,
                    CardPrefab = GetCardPrefab(cardName) // Assign the correct prefab
                };

                // Check if the prefab is found
                if (card.CardPrefab == null)
                {
                    Debug.LogWarning($"Prefab for {cardName} not found in cardPrefabDict.");
                }

                cards.Add(card);
            }
        }
    }

    private GameObject GetCardPrefab(string cardName)
    {
        if (cardPrefabDict.TryGetValue(cardName, out GameObject prefab))
        {
            return prefab;
        }
        return null; // If no matching prefab is found, return null
    }

    public void Shuffle()
    {
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
        if (cards.Count > 0)
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        return null;
    }
}

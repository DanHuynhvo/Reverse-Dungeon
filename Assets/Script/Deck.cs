using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject[] cardPrefabs; // Assign all card prefabs in the Inspector
    private Dictionary<string, GameObject> cardPrefabDict; // For quick lookup by name
    private List<Card> cards = new List<Card>();

    void Start()
    {
        cards = new List<Card>();
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        // Create a dictionary for quick lookup of card prefabs by name
        cardPrefabDict = new Dictionary<string, GameObject>();
        foreach (GameObject prefab in cardPrefabs)
        {
            cardPrefabDict[prefab.name] = prefab;
        }

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
        Debug.LogWarning($"Prefab for {cardName} not found!");
        return null;
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

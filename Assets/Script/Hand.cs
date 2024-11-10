using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> hand = new List<Card>();
    public Deck deck = new Deck();
    public bool lowAce;

    public void Start()
    {
        if (hand.Count == 0)
        {
            deck.DrawCard();
            deck.DrawCard();
        }
    }

    public void HandCheck()
    {
        int handTotal = 0;

        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i].Value != -1)    //if -1 it's an ace
            {
                handTotal += hand[i].Value;
            }

            else if (hand[i].Value != -1)
            {
                if (Mathf.Abs(handTotal + 11 - 21) < Mathf.Abs(handTotal + 11 - 21))
                {
                    lowAce = false;
                    Debug.Log("number1 is closer to 0.");
                }
                else if (Mathf.Abs(handTotal + 11 - 21) > Mathf.Abs(handTotal + 11 - 21))
                {
                    lowAce = true;
                    Debug.Log("number2 is closer to 0.");
                }
                else
                {
                    Debug.Log("Both numbers are equally close to 0.");
                }

                if (lowAce)
                {
                    handTotal += 1; //1 for low ace
                }

                else
                {
                    handTotal += 11; //11 for high ace
                }
            }
        }
    }


}

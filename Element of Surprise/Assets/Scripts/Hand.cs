using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    List<Card> cards;

    private void Start()
    {
        cards = new List<Card>();
    }

    // for when you want to send a card from the hand to the discard pile
    void DiscardCard()
    {

    }

    // getting a card from a deck
    public void RecieveCard(Card card)
    {

    }

    // calculates the value of the hand including all the rules
    public void CalcValues()
    {

    }

    // for showing synergy visually
    public void CalcVisuals()
    {

    }
}

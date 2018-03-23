using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardContainer {
    int maxCards = 10;
    List<Card> cards;
    List<CardPosition> cardSlots;

/*
public void Deal(Card card, CardContainer dest)
private void SendCard(Card card, CardContainer dest)
public void RecieveCard(Card card)
private void AddCard(Card card)
private void RemoveCard(Card card)
*/

    private void Start()
    {
        cards = new List<Card>();
        GenerateSlots(maxCards);
    }

    //constructor
    public Hand()
    {

    }

    private void GenerateSlots(int numSlots)
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

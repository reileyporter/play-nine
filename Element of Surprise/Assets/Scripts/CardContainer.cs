using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardContainer : MonoBehaviour {
    List<Card> cardList;
    bool hasMaxNumCards = false;
    int maxNumCards;

    private void Start()
    {
        cardList = new List<Card>();
    }

    /* public accessor to set a card, called by Match */
    public void Deal(Card card, CardContainer dest)
    {
        /* implementation/error checking */
        SendCard(card, dest); /* ship the card off */
        /* rest of implementation */
    }

    private void SendCard(Card card, CardContainer dest)
    {
        /* implementation/error checking */
        // double checking that this container has the card
        if (cardList.Contains(card) == false) Debug.LogError("CardContainer is trying to send a card it shouldnt be");
        dest.RecieveCard(card);
        // removes card from this containers list
        RemoveCard(card);
        
        
    }

    public void RecieveCard(Card card)
    {

        /* implementation/errorchecking */
        if (hasMaxNumCards == false || cardList.Count < maxNumCards && hasMaxNumCards == true)
        AddCard(card);
        else Debug.LogError("CardContainer is trying to overfill");
        
        // visual stuff
        // TODO set card destination 
    }

    private void AddCard(Card card)
    {
        cardList.Add(card);
    }

    private void RemoveCard(Card card)
    {
        cardList.Remove(card);
    }

    public void ClearContainer()
    {
        cardList.Clear();
    }

}


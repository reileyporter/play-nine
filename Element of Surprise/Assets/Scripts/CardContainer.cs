using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardContainer : MonoBehaviour {
    List<Card> cardList;

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
        dest.RecieveCard(card);
        /* rest of implementation */
    }

    public void RecieveCard(Card card)
    {

        /* implementation/errorchecking */
        AddCard(card);
        /* rest of implementation */
    }

    private void AddCard(Card card)
    {

        cardList.Add(card);
    }

}


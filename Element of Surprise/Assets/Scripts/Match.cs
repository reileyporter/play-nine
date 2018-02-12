using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {
    private int numPlayers = 4;
    private int deckCount = 3;
    private List<Player> players;
    private bool rankedFlag;
    private Deck matchDeck;
    private Discard matchDiscard;
    private float matchStart;
    private float TurnTimeRemaining;

    Match(bool ranked)
    {
        rankedFlag = ranked;
    }

    private void Deal(Player player, CardContainer dest)
    {

    }

    private void Swap(Card card, CardContainer dest, CardContainer src)
    {

    }

    private void PlayerTurn()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Giving a card to a player
    // Check if hands are too full
    // Deck.Dealcard() (returns a gameobject aka card)
    // Hand.recieveCard(card)
}

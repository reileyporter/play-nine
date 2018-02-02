using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int numberPlayers = 2;
    public List<Field> fields;
    public Deck deck;
    public Deck discardPile;
    public Card hoveredCard;
    public TurnTracker turnTracker;
    public bool turnTaken;
    public Card selectedCard;
    public ScoreTracker scoreTracker;

    bool dealing;
    int playerTurn = 1; // 1 is player 1, etc..

    public enum Stage
    {
        dealing,
        teeing,
        playing,
        over
    }
    public Stage currStage;

    // Use this for initialization
    void Start()
    {
        
        currStage = Stage.dealing;
        deck.GenerateDeck();
        if (deck == null || discardPile == null)
        {
            Debug.Log("Something is null in roundmanager check from the editor!!!");
        }
        if (turnTracker == null)
        {
            Debug.Log("turn tracker is empty!!@!@!");
        }
		for (int i = 0; i < fields.Count; i++)
		{
            
            fields[i].playerNumber = i;
		}

    }
    void Update()
    {
        if (currStage == Stage.dealing && dealing == false)
        {
            StartCoroutine("DealCards");
            StartCoroutine("SingleCard");
            currStage = Stage.teeing;
            turnTaken = false;
        } else if (currStage == Stage.teeing)
        {
			if (turnTaken == true)
			{
				playerTurn++;
				for (int i = 0; i < fields.Count; i++)
				{
					fields[i].SetPermissions(playerTurn);
				}
				turnTaken = false;
			}
        }
        else if (currStage == Stage.playing && turnTaken == false)
        {
            turnTracker.SetTurn(playerTurn % numberPlayers);
            for (int i = 0; i < fields.Count; i++) fields[i].SetPermissions(playerTurn);
            if (turnTaken == true)
            {
                playerTurn++;
                for (int i = 0; i < fields.Count; i++)
                {
                    fields[i].SetPermissions(playerTurn);
                }
                turnTaken = false;
            }
        }
    }

    // call this to change players turn
    public void SetTurn()
    {
        
    }

    IEnumerator DealCards()
    {
        dealing = true;
        for (int i = 0; i < fields[0].maxCards; i++)
        {
            for (int j = 0; j < numberPlayers; j++)
            {
                //Debug.Log("dealing card");
				deck.targetField = fields[j];
				deck.DealCard();
                yield return new WaitForSeconds(.1f);
            }
        }
        currStage = Stage.playing;
        dealing = false;
    }

    IEnumerator SingleCard()
    {
        yield return new WaitForSeconds(2f);
        deck.RevealCard(discardPile);
        
    }

    public void ResetGame()
    {
        if (dealing == false){
            for (int j = 0; j < numberPlayers; j++)
            {
                foreach (Transform child in fields[j].transform)
                {
                    Destroy(child.gameObject);
                }
            }
            // clears deck and generates new one
            deck.GenerateDeck();
            // clears flipped cards
            if (deck.flippedCard != null)
            {
                Destroy(deck.flippedCard.gameObject);
                deck.flippedCard = null;
            }
            if (discardPile.flippedCard != null)
            {
                Destroy(discardPile.flippedCard.gameObject);
                discardPile.flippedCard = null;
            }
            deck.totalCards = 0;
            Start();
        }
    }

}
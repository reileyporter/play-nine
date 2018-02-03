using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    /* TODO: encapsulate deck properly */
    public List<int> deck; /* actual cards */
    private int numDuplicateDecks = 4;
    private int highestCardNumber = 10; // still has 0 and -5
    private GameObject tempObject;

    /* do we need this targetField reference?
     * we could probably just get away with
     * leaving it out and referencing the 
     * only field in the entire game instance...
     * either way...
     * TODO: encapsulate targetField properly
     */
    private Field targetField;
    public Field TargetField { get; set; }
    private Card card;
    private Card flippedCard;
    public Card FlippedCard { get; set; }
    private int totalCards;
    public int TotalCards { get; set; }
    public GameObject baseCard; // Stopped here, continue encapsulation
    public GameObject topPosition;
    public RoundManager roundManager;
    public Behaviour halo;

    void Start()
    {
        /* generate deck should happen somewhere else? */
        GenerateDeck();
        halo = (Behaviour)GetComponent("Halo");
        roundManager = GetComponentInParent<RoundManager>();
        totalCards = 0;
    }

	public void Update()
	{
		if (flippedCard != null)
		{
			flippedCard.TargetPosition = topPosition;
			flippedCard.Upright = true;
		}
		if (deck.Count == 0)
		{
			// renderer.enabled = false;
		}
	}

    public void GenerateDeck()
    {
        deck.Clear();
        for (int i = 0; i < numDuplicateDecks; i++)
        {
            for (int j = -1; j <= highestCardNumber; j++)
            {
				if (j == -1)
					deck.Add(-5);
                else deck.Add(j);
            }
        }
        totalCards = deck.Count;
    }

	// instantiates card then passes it to the targetted player's field
    // thisll be used at the start of the round
	public void DealCard ()
    {
        if (deck.Count > 0 && TargetField.IsFull() == false)
        {
            // selects random card then removes it
            int selectedvalue = deck[Random.Range(0, deck.Count)];
            deck.Remove(selectedvalue);
            // generates a card to be passed
            var tempCard = Instantiate(baseCard, transform.position, transform.rotation);
            tempCard.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            card = tempCard.GetComponent<Card>();
            // sets the approprate value for the card
            card.Value = selectedvalue;
            // sets a class for the card
            card.CardClass = (Card.Class)Random.Range(0, 4);
            // sets a type for the card
            card.CardType = (Card.Type)Random.Range(0, 5);
            // sets the target for the card so it moves to the field
            card.transform.SetParent(roundManager.transform);
            // pass the card to the field
            TargetField.AddCard(card);
            totalCards--;

        } // add logic for reshuffle or maybe make the update check for cards == 0 so it'll do it automatically
    }

    public void AddCard(Card tempCard)
    {
        deck.Add(card.Value);
    }


    public void RevealCard(Deck discardPile)
    {
		// selects random card then removes it
		int selectedvalue = deck[Random.Range(0, deck.Count)];
		deck.Remove(selectedvalue);

		// generates a card to be passed
		var tempCard = Instantiate(baseCard, transform.position, transform.rotation);
		tempCard.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
		card = tempCard.GetComponent<Card>();
		// sets the approprate value for the card
		card.Value = selectedvalue;
		// sets a class for the card
		card.CardClass = (Card.Class)Random.Range(0, 4);
        // sets a type for the card
        card.CardType = (Card.Type)Random.Range(0, 5);
        // sets the target for the card so it moves to the field
        card.transform.SetParent(roundManager.transform);
        discardPile.SetFlippedCard(card);
        totalCards--;
    }

    public void SetFlippedCard(Card card)
    {
        flippedCard = card;
    }

	// Mouse Functions
	void OnMouseEnter()
	{
            halo.enabled = true;
	}
	void OnMouseExit()
	{
			halo.enabled = false;
	}

}

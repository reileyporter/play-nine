using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    // Visual Variables
    GameObject deckTop;
    public GameObject cardBack;
    Card card;

    // Gameplay Variables
    List<int> deckTypes;
    List<int> deckClasses;
    int numDecks, totalCards;
    


    // Use this for initialization
    void Start()
    {
        deckTop = transform.GetChild(0).gameObject; // gets the cards back
        GenerateDeck(); 
    }

    public void GenerateDeck()
    {
        deckTypes.Clear();
        deckClasses.Clear();
        for (int i = 0; i < numDecks; i++)
        {
            // j < num types * num classes
            for (int j = 0; j < 6 * 5; j++)
            {
                deckClasses.Add(j % 5);
                deckTypes.Add(j % 6);
            }
        }
        totalCards = deckClasses.Count;
    }

    // instantiates card then passes it to the targetted player's field
    // thisll be used at the start of the round
    public void DealCard(Hand hand)
    {
        if (totalCards > 0 && hand.IsFull() == false)
        {
            // selects random card, saves its value, then removes it
            int randomValue = Random.Range(0, deckClasses.Count);
            int selectedClass = deckClasses[randomValue];
            int selectedType = deckTypes[randomValue];
            deckClasses.Remove(randomValue);
            deckTypes.Remove(randomValue);
            // generates a card to be passed
            var tempCard = Instantiate(cardBack, transform.position, transform.rotation);
            card = tempCard.GetComponent<Card>();
            card.FlipOver();

            // sets a class for the card
            card.cardClass = (Card.Class)selectedClass;
            // sets a type for the card
            card.cardType = (Card.Type)selectedType;
            // sets the target for the card so it moves to the field

            // TODO make a child of something to organize it

            // pass the card to the field
            // TargetField.AddCard(card);
            totalCards--;

        } // add logic for reshuffle or maybe make the update check for cards == 0 so it'll do it automatically
    }

}

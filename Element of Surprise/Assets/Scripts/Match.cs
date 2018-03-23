using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {
    private int numPlayers = 4;
    private int deckCount = 3;
    private List<Player> players;
    private List<Hand> hands;
    private bool rankedFlag;
    private Deck matchDeck;
    private Discard matchDiscard;
    private float matchStart;
    private float TurnTimeRemaining;
    private List<Card> availableCards;
    private enum PlayerTurn
    {
        Player1,
        Player2,
        Player3,
        Player4
    } PlayerTurn playerTurn;

    public CameraMovement mainCamera;
    public List<GameObject> playerPositions;
    public List<string> playerNames;


    private void Start()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            Player playerClone = new Player(i, hands[i], playerPositions[i], playerNames[i]);
        }
        playerTurn = PlayerTurn.Player1;
        matchDeck = new Deck();
        availableCards = new List<Card>();
    }

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

    private void Turn(PlayerTurn whatTurn)
    {
        SetCamera();
    }
	
    private void SetCamera()
    {
        switch (playerTurn)
        {
            case PlayerTurn.Player1:
                mainCamera.SetCameraPosition(playerPositions[1]);
                break;
            case PlayerTurn.Player2:
                mainCamera.SetCameraPosition(playerPositions[2]);
                break;
            case PlayerTurn.Player3:
                mainCamera.SetCameraPosition(playerPositions[3]);
                break;
            case PlayerTurn.Player4:
                mainCamera.SetCameraPosition(playerPositions[4]);
                break;
        }
    }

    private Card GenerateCard(int j)
    {
        Card tempCard;
        int typeVal = j % 6;
        int classVal = j % 5;
        Card.Class selectedClass = new Card.Class();
        Card.Type selectedType = new Card.Type();
        switch (typeVal)
        {
            case 0:
                selectedType = Card.Type.air;
                break;
            case 1:
                selectedType = Card.Type.earth;
                break;
            case 2:
                selectedType = Card.Type.fire;
                break;
            case 3:
                selectedType = Card.Type.lightning;
                break;
            case 4:
                selectedType = Card.Type.nature;
                break;
            case 5:
                selectedType = Card.Type.water;
                break;
            default:
                Debug.LogError("Something Broke in GenerateCard in Match.cs");
                break;
        }

        switch(classVal)
        {
            case 0:
                selectedClass = Card.Class.beast;
            break;
            case 1:
                selectedClass = Card.Class.golem;
                break;
            case 2:
                selectedClass = Card.Class.human;
                break;
            case 3:
                selectedClass = Card.Class.sprite;
                break;
            case 4:
                selectedClass = Card.Class.wizard;
                break;
            default:
                Debug.LogError("Something Broke in GenerateCard in Match.cs");
                break;
        }
        tempCard = new Card(selectedType, selectedClass);

        return tempCard;
    }

    private void GenerateDeck()
    {
        if (matchDeck.NumCards != 0)
        {
            matchDeck.ClearContainer();
        }

        for (int i = 0; i < deckCount; i++)
        {
            // j < num types * num classes
            for (int j = 0; j < 6 * 5; j++)
            {
                // generate the actual deck within match
                availableCards.Add(GenerateCard(j));
            }
        }
        matchDeck.NumCards = availableCards.Count;
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Giving a card to a player
    // Check if hands are too full
    // Deck.Dealcard() (returns a gameobject aka card)
    // Hand.recieveCard(card)
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // game state to be viewed by players
    private Hand playerHand;
    public Hand PlayerHand { get; set; }
    private string playerName;
    private int playerNumber;
    public string PlayerName { private set; get; }
    private int score;
    public int Score { set; get; } // should only be used by match
    private GameObject playerPosition;
    private Card currSelectedCard;
    // some sort of player icon
    // some sort of deck back

    public Player(int assignedNumber, Hand assignedHand, GameObject assignedPlayerPosition, string assignedPlayerName)
    {
        playerNumber = assignedNumber;
        playerHand = assignedHand;
        playerPosition = assignedPlayerPosition;
        playerName = assignedPlayerName;
    } 
}

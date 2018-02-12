using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // game state to be viewed by players
    private Hand playerHand;
    public Hand PlayerHand { get; set; }
    private string playerName;
    public string PlayerName { private set; get; }
    private int score;
    public int Score { set; get; } // should only be used by match
    private GameObject cameraPosition;
    private GameObject handPosition;
    private Card currSelectedCard;
    // some sort of player icon
    // some sort of deck back

    Player()
    {

    } 
}

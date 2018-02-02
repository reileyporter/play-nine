using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public Text text;
    public List<Card> cards;
    public List<int> visibleValues;
    public int maxCards = 8;
    public int fieldWidth = 4;
    public Vector3 currPointer;
    public int currValue;
    public List<GameObject> fieldPositions;
    public RoundManager roundManager;
    public int playerNumber;
    bool full;

    void Start()
    {
       // text = GetComponent<Text>();
        roundManager = GetComponentInParent<RoundManager>();
        full = false;
        currPointer = transform.position;
        for (int i = 0; i < maxCards; i++)
        {
            Vector3 cardPos = transform.position;
            cardPos.x += (i % 4) * 2.0f;
            if (i >= 4) cardPos.y -= 2.0f;

            var fieldPosition = new GameObject();
            fieldPosition.transform.position = cardPos;
            fieldPosition.transform.parent = transform;
            fieldPosition.name = "FieldPosition" + i.ToString();

            fieldPositions.Add(fieldPosition);
        }
    }

    public void AddCard(Card card)
    {
        if (cards.Count < maxCards)
        {
            card.SetTarget(fieldPositions[cards.Count]);
            cards.Add(card);
			//Debug.Log(cards.Count);
			if (cards.Count == maxCards)
                full = true;
            card.transform.SetParent(card.targetPosition.transform);
        }
        else Debug.Log("Field is full");
        
    }

    public GameObject GetNextTarget()
    {
        return fieldPositions[cards.Count];
    }

    public bool IsFull(){return full;}

    public void RevealCard(){
        
    }

    public void SetPermissions(int tempPlayerNumber){
        //text.text += playerNumber.ToString();
        if (playerNumber != tempPlayerNumber)
        {
            // no permission for turn, set all cards to non selectable
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].selectable = false;
            }
        }
		// has permission, sets cards to be selectable
		else for (int i = 0; i < cards.Count; i++)
		{
			cards[i].selectable = true;
		}
    }
}
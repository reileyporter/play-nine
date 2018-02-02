using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Variables
    public GameObject targetPosition;
    public RoundManager roundManager;
    public bool selectable = true;
    public bool pileCard;
    public enum Suit
    {
        diamonds,
        clubs,
        hearts,
        spades
    }
    public Suit suit;

    int value = 1;
    public bool upright;
    public float rotationSpeed = .1f;
    Behaviour halo;


 
    void Start()
    {
		halo = (Behaviour)GetComponent("Halo");
		roundManager = GetComponentInParent<RoundManager>();
    }


    void Update()
    {
        if (targetPosition != null)
        {
            if (Vector3.Distance(targetPosition.transform.position, transform.position) > .001f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition.transform.position, Time.deltaTime * 2);
            }
        }
        else Debug.Log("targetPosition is null");

        if (upright == true)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        } else
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }


    // Mouse Functions
    void OnMouseEnter()
    {
        if (selectable)
        {
            halo.enabled = true;
            roundManager.hoveredCard = this;
        }
    }
    void OnMouseExit()
    {
        if (selectable)
        {
            halo.enabled = false;
            roundManager.hoveredCard = null;
        }
    }

    private void OnMouseDown()
    {
        if (selectable)
        {
            Debug.Log("card mousedown working");
            roundManager.turnTaken = true;
        }
    }


    // Sets and Gets
    public void SetValue(int a) { value = a; }
	public int GetValue() { return value; }
	public void SetSuit(int a)
	{
		if (a == 0) suit = Suit.diamonds;
		else if (a == 1) suit = Suit.clubs;
		else if (a == 2) suit = Suit.hearts;
		else suit = Suit.spades;
	}
	public void SetTarget(GameObject a) { targetPosition = a; }
}

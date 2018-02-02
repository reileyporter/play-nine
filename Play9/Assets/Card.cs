using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    /* Variables */

    /* unity-specific */
    public GameObject targetPosition;  /* handle for targetPos */
    private RoundManager roundManager; /* handle for roundManager obj */
    public Behaviour halo;             /* ring of light around cards */

    /* enum variables */
    public Class cardClass; /* class of card */
    public Type cardType;   /* type of card */

    /* primitives */
    public int value;   /* value of card */
    public float rotationSpeed = .1f;

    /* bool flags */
    public bool selectable = true; /* flag */
    public bool pileCard;          /* Used later */
    public bool upright;           /* flag */

    /* enums */
    public enum Class
    {
        diamonds,
        clubs,
        hearts,
        spades
    }


    public enum Type
    {
        typeA,
        typeB,
        typeC,
        typeD
    }
 
    void Start()
    {
		halo = (Behaviour)GetComponent("Halo");
		roundManager = GetComponentInParent<RoundManager>();
    }


    void Update()
    {
        if (targetPosition != null &&
            Vector3.Distance(targetPosition.transform.position, transform.position) > .001f)
        {
            transform.position = Vector3.Lerp(transform.position,
                targetPosition.transform.position, Time.deltaTime * 2);
        }
        else Debug.Log("targetPosition is null");

        if (upright == true)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }


    // Mouse Functions
    private void OnMouseEnter()
    {
        if (selectable)
        {
            halo.enabled = true;
            Debug.Log("hover halo on");
            roundManager.hoveredCard = this;
        }
    }
    private void OnMouseExit()
    {
        if (selectable)
        {
            halo.enabled = false;
            Debug.Log("hover halo gone");
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


    /* setters/getters */
    /* card value */
    public void SetValue(int a) { value = a; }
	public int GetValue() { return value; }

    /* target */
    public void SetTarget(GameObject a) { targetPosition = a; }

    /* class */
    /* TODO: enums are ints, we can just pass those instead of int a */
	public void SetClass(int a)
	{
        switch(a)
        {
            case 0:
                cardClass = Class.diamonds;
                break;
            case 1:
                cardClass = Class.clubs;
                break;
            case 2:
                cardClass = Class.hearts;
                break;
            case 3:
                cardClass = Class.spades;
                break;
            default:
                Debug.Log("error: non-existent class used");
                /* TODO: add error handling here */
                break;
        }
	}

    /* type */
    /* TODO: enums are ints, we can just pass those instead of int a */
    public void setType(int a)
    {
        switch(a)
        {
            case 0:
                cardType = Type.typeA;
                break;
            case 1:
                cardType = Type.typeB;
                break;
            case 2:
                cardType = Type.typeC;
                break;
            case 3:
                cardType = Type.typeD;
                break;
            default:
                Debug.Log("error: non-existent type used");
                /* TODO: add error handling here */
                break;
        }
    }
}

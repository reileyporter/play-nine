using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    // OLD CARD 
    /* Variables */

    /* unity-specific */
    private GameObject targetPosition;  /* handle for targetPos */
    public GameObject TargetPosition { get; set; }
    private RoundManager roundManager; /* handle for roundManager obj */
    public Behaviour halo;             /* ring of light around cards */

    /* enum variables */
    private Class cardClass; /* class of card */
    public Class CardClass { get; set; }
    private Type cardType;   /* type of card */
    public Type CardType { get; set; }

    /* primitives */
    private int value;   /* value of card */
    public int Value { get; set; }
    private string modifier; /* modifier of card */
    public string Modifier { get; set; }
    private float rotationSpeed = .1f; /* not used yet? */

    /* bool flags */
    private bool selectable; /* flag */
    public bool Selectable { get; set; }
    private bool pileCard;   /* Used later */
    private bool upright = true;    /* flag */
    public bool Upright { get; set; }

    /* enums */
    public enum Class
    {

        diamonds,
        hearts,
        clubs,
        spades

        /* for later
        wizard,
        sprite,
        human,
        beast,
        golem
        */
    }


    public enum Type
    {
        fire,
        air,
        lightning,
        nature,
        earth,
        water
    }
 
    void Start() {
		halo = (Behaviour)GetComponent("Halo");
		roundManager = GetComponentInParent<RoundManager>();
    }


    void Update() {
        if (TargetPosition != null &&
            Vector3.Distance(TargetPosition.transform.position, transform.position) > .001f)
        {
            transform.position = Vector3.Lerp(transform.position,
                TargetPosition.transform.position, Time.deltaTime * 2);
        }
        else Debug.Log("targetPosition is null"); /* this prints so much */

        if (upright == true)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }


    // Mouse Functions
    private void OnMouseEnter()
    {
        if (Selectable)
        {
            halo.enabled = true;
            Debug.Log("hover halo on");
            roundManager.hoveredCard = this;
        }
    }
    private void OnMouseExit()
    {
        if (Selectable)
        {
            halo.enabled = false;
            Debug.Log("hover halo gone");
            roundManager.hoveredCard = null;
        }
    }

    private void OnMouseDown()
    {
        if (Selectable)
        {
            Debug.Log("card mousedown working");
            roundManager.turnTaken = true;
        }
    }
}

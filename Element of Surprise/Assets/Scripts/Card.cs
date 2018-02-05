using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    // UI related Variables
    Vector3 targetPosition; // for following the mouse around
    public GameObject cardsAssignedPosition; // where the card should be, as assigned by the deck or discard pile
    Vector3 velocity = Vector3.zero; // for the SmoothDamp function
    bool grabbed = false;
    public List<GameObject> nearbyObjects;
    Proximity proximity;

    // Logic Related Variables

    // Test Variables

    // Use this for initialization
    void Start () {
        // Test stuff
        proximity = GetComponentInChildren<Proximity>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cardsAssignedPosition != null && !grabbed)
        {
            transform.position = Vector3.SmoothDamp(transform.position, cardsAssignedPosition.transform.position, ref velocity, /*smoothTime*/ .1f, /*max speed, didn't seem to affect much */ 1000.0f);
        }
	}

    void OnMouseDrag()
    {
		// converts mouse position into a world position based on the camera
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // at this point the card would snap to the center of the mouse, so I added the smoothing because of that

        // z position needs to still be set properly
        targetPosition.z = -1f;
        // Moves the card to position of the target, and dampens the 
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, /*smoothTime*/ .1f , 1000.0f);
    }

    private void OnMouseDown()
    {
        grabbed = true;
    }

    private void OnMouseUp()
    {
        grabbed = false;
        // This allows it to shift between targets
        if (proximity.IsListEmpty() == false)
        {
            if (proximity.GetClosest().GetComponentInParent<CardPosition>().isValidMove == true)
                cardsAssignedPosition = proximity.GetClosest();
        }
    }
}

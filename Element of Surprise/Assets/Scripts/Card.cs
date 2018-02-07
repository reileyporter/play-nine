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
    public enum Class
    {
        wizard,
        sprite,
        human,
        beast,
        golem
    }
    public Class cardClass;

    public enum Type
    {
        fire,
        air,
        lightning,
        nature,
        earth,
        water
    }
    public Type cardType;

    // Use this for initialization
    void Start () {
        proximity = GetComponentInChildren<Proximity>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cardsAssignedPosition != null && !grabbed)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(cardsAssignedPosition.transform.position.x, cardsAssignedPosition.transform.position.y, -1), ref velocity, /*smoothTime*/ .1f, /*max speed, didn't seem to affect much */ 1000.0f);
        }
        else if (cardsAssignedPosition != null && grabbed)
        {
            // telegraph where the card would go to if let go
            /*
            if (!proximity.IsListEmpty() && proximity.GetClosest().GetComponentInParent<CardPosition>().isValidMove == true)
            {
                proximity.GetClosest();
            }
            */
        }
	}

    public void FlipOver()
    {
        Rotate90();
        // Instantiate card based on values and delete old one
        Rotate90();
    }

    void Rotate90()
    {
        var oldRotation = transform.rotation;
        transform.Rotate(0, -90, 0);
        var newRotation = transform.rotation;

        for (float t = 0.0f; t <= 1.0; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Slerp(oldRotation, newRotation, t);
        }

        transform.rotation = newRotation; // To make it come out at exactly 90 degrees

    }

    void OnMouseDrag()
    {
		// converts mouse position into a world position based on the camera
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // at this point the card would snap to the center of the mouse, so I added the smoothing because of that

        // z position needs to still needed to be set
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    // UI related Variables
    Vector3 targetPosition; // for following the mouse around
    GameObject cardsNormalPosition; // where the card should be, as assigned by the deck or discard pile
    Vector3 velocity = Vector3.zero; // for the SmoothDamp function

    // Logic Related Variables

    // Test Variables
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        // Test stuff
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cardsNormalPosition != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, cardsNormalPosition.transform.position, ref velocity, /*smoothTime*/ .1f, 1000.0f);
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
}

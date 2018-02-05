using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    // UI related Variables
    Vector3 targetPosition; // for following the mouse around
    Vector3 cardsNormalPosition; // where the card should be, as assigned by the deck or discard pile
    float smoothTime = .1f;
    private Vector3 velocity = Vector3.zero;

    // Logic Related Variables

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDrag()
    {
		// converts mouse position into a world position based on the camera
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // at this point the card would snap to the center of the mouse, so I added the smoothing because of that

        // z position needs to still be set properly
        targetPosition.z = -1f;
        // Moves the card to position of the target, and dampens the 
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, 1000.0f);
    }
}

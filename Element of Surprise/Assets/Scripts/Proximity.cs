using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour {
    public List<GameObject> nearbyObjects;

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll);
        if (coll.gameObject.tag == "CardPosition")
        nearbyObjects.Add(coll.gameObject);
    }

    void OnTriggerExit2D(Collider2D coll)
	{
        if (coll.gameObject.tag == "CardPosition")
        nearbyObjects.Remove(coll.gameObject);
	}

}

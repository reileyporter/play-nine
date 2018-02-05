using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour {
    public List<GameObject> nearbyObjects;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "CardPosition")
            nearbyObjects.Add(coll.gameObject);
    }

    void OnTriggerExit2D(Collider2D coll)
	{
        if (coll.gameObject.tag == "CardPosition")
        nearbyObjects.Remove(coll.gameObject);
    }

    public bool IsListEmpty()
    {
        return (nearbyObjects.Count == 0);
    }

    // Gets closest object from the list
    public GameObject GetClosest()
    {
        float shortestDistance = 0;
        int currShortest = 0;
        for (int i = 0; i < nearbyObjects.Count; i++)
        {
            if (i == 0) shortestDistance = getDistance(nearbyObjects[i]);
            else if (shortestDistance > getDistance(nearbyObjects[i]))
            {
                currShortest = i;
            }
        }
        return nearbyObjects[currShortest];
    }

    // Helper function to get the 2 dimensional distance for GetClosest
    float getDistance (GameObject otherObject)
    {
        return Vector2.Distance(new Vector2(otherObject.transform.position.x, otherObject.transform.position.y),
                                                            new Vector2(transform.position.x, transform.position.y));
    }

}

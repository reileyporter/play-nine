using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class CardText : MonoBehaviour {
    Card cardScript;
    TextMesh textMesh;
	

	void Start () {
        cardScript = GetComponentInParent<Card>();
        textMesh = GetComponent<TextMesh>();
 
        textMesh.text = cardScript.GetValue().ToString();

        if (cardScript.cardClass == Card.Class.hearts)
        {
            textMesh.color = Color.red;
            textMesh.text += " <3";
        }
        else if (cardScript.cardClass == Card.Class.diamonds)
        {
            textMesh.color = Color.red;
            textMesh.text += " <>";
        }
        else if (cardScript.cardClass == Card.Class.clubs)
        {
            textMesh.color = Color.black;
            textMesh.text += " ----{}";
        }
        else
        {
            textMesh.color = Color.black;
            textMesh.text += " <3-";
        }
	}
}

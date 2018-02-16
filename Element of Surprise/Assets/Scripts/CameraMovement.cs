using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Camera mainCamera;
    GameObject cameraPosition;
    Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraPosition != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(cameraPosition.transform.position.x,
                                                    cameraPosition.transform.position.y, -1), ref velocity, 1.0f, 10.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraPosition.transform.rotation, .03f);
        }
    }

    public void SetCameraPosition(GameObject position)
    {
        cameraPosition = position;
    }
}

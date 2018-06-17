using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControler : MonoBehaviour {

	private GameObject camera;

	// Use this for initialization
	void Start () {
		camera = transform.Find("Camera").gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var scroll = Input.GetAxis("Mouse ScrollWheel");
		if (scroll != 0f )
		{
			Vector3 temp = camera.transform.position;
            temp.z += scroll * 3;
			temp.y -= scroll;
            camera.transform.position = temp;
		}
	}
}

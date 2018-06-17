using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceForward : MonoBehaviour {

	public float factor = 1f;

	void Start () {
		var force = transform.forward * factor;
		GetComponent<Rigidbody>().AddForce(force);
	}
	
	void FixedUpdate () {
	}
}

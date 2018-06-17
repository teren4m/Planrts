using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour {

	private List<GameObject> gravityTarget = new List<GameObject>();
	private GameObject parent;
	private float massParent;
	public float g = 100f;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
		massParent = parent.GetComponent<Rigidbody>().mass;
	}
	
	void FixedUpdate () {
		foreach(GameObject obj in gravityTarget){
			float dist = Vector3.Distance(parent.transform.position, obj.transform.position);
			
			Rigidbody rigidbodyObj = obj.GetComponent<Rigidbody>();
			float massObj = rigidbodyObj.mass;

			var vectorToParent = parent.transform.position - obj.transform.position;
			var vectorToParentNorm = vectorToParent / vectorToParent.magnitude;

			double preFoarce = (massParent * massObj) / Math.Pow(dist, 2);
			float force = ((float)preFoarce) * g;

			var totalForce = vectorToParentNorm * force;
			rigidbodyObj.AddForce(vectorToParentNorm * force);
		}
	}

	void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
		if(rb != null && !rb.isKinematic){
			Debug.Log("Add " + other.gameObject.name);
			gravityTarget.Add(other.gameObject);
		}
    }

	void OnTriggerExit(Collider other)
    {
		Debug.Log("Exit " + other.gameObject.name);
		gravityTarget.Remove(other.gameObject);
    }
}

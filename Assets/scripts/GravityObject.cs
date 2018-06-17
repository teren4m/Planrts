using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour {

	public float gravityFactor = 2.0f;

	private GameObject gravity;
	private Rigidbody rb;

	public GravityObject(){
	}

	void Start () {
		gravity = transform.Find("GravityArea").gameObject;
		rb = GetComponent<Rigidbody>();
		float gravityBound = rb.mass * gravityFactor;
		gravity.transform.localScale += new Vector3(gravityBound, gravityBound, gravityBound);
		Debug.Log("Hello world" + gravity.name);
	}
	
	void Update () {
		
	}
}

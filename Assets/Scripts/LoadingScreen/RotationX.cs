using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationX : MonoBehaviour {
	public Vector3 rotationObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rotationObject += Vector3.forward * 360 * Time.deltaTime;
		transform.rotation = Quaternion.Euler(rotationObject);
	}
}

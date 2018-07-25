using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationZ : MonoBehaviour {
	public Vector3 rotationObject;

	void Update () {
		rotationObject += Vector3.forward * 360 * Time.deltaTime;
		transform.rotation = Quaternion.Euler(rotationObject);
	}
}

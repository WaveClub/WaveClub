using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	public Vector3 rotationObject;
	[Header("Settings")]
	[Range(1f, 360f)]
	public float speed;
	public bool isClockwise;

	public bool isForwardRotation;
	public bool isUpRotation;
	public bool isRightRotation;

	private Vector3 vector;

	void Start () {
		if (isClockwise) {
			vector = (isForwardRotation ? Vector3.forward : Vector3.zero) + (isUpRotation ? Vector3.up : Vector3.zero) + (isRightRotation ? Vector3.right : Vector3.zero);
		} else {
			vector = (isForwardRotation ? Vector3.back : Vector3.zero) + (isUpRotation ? Vector3.down : Vector3.zero) + (isRightRotation ? Vector3.left : Vector3.zero);
		}
	}

	void Update () {
		rotationObject += vector * 360 * Time.deltaTime;
		transform.rotation = Quaternion.Euler(rotationObject);
	}
}

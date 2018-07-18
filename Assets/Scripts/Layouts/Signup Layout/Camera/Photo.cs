using System;
using UnityEngine;

public class Photo : MonoBehaviour
{
	public Vector3 rotationObject;

	void Start() {
		#if UNITY_IPHONE
			rotationObject = new Vector3 (0, 0, -90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif

		#if UNITY_ANDROID
			rotationObject = new Vector3 (0, 0, 90);
			transform.rotation = Quaternion.Euler (rotationObject);
			//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		#endif
	}
}


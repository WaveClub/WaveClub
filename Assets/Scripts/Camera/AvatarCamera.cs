using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvatarCamera : MonoBehaviour, IPointerDownHandler {
	public GameObject image;
	public RawImage rawimage;
	public Vector3 rotationObject;

	void Start() {
		CameraManager.Instance.LinqCameraWithTextura (rawimage, image);
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (CameraManager.Instance.GetCameraStatus()) {
			CameraManager.Instance.StopCamera ();
		} else {
			CameraManager.Instance.StartCamera ();
		}

		#if UNITY_IPHONE
			rotationObject = new Vector3 (0, 0, -90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif

		#if UNITY_ANDROID
			rotationObject = new Vector3 (0, 0, 90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif
	}
}

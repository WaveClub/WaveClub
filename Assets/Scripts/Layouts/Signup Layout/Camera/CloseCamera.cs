using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseCamera : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public RawImage photoImage;
	public Vector3 rotationObject;

	void Start() {
		#if UNITY_IPHONE
			rotationObject = new Vector3 (0, 0, -90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif

		#if UNITY_ANDROID
			rotationObject = new Vector3 (0, 0, 90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif
	}

	public void OnPointerUp(PointerEventData eventData) {
		CameraManager.Instance.GetPhoto (photoImage);
		CameraManager.Instance.StopCamera ();
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

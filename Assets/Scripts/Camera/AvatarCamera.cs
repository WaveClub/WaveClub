using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvatarCamera : MonoBehaviour, IPointerDownHandler {
	public GameObject image;
	public RawImage rawimage;

	void Start() {
		CameraManager.Instance.LinqCameraWithTextura (rawimage, image);
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (CameraManager.Instance.getCameraStatus()) {
			CameraManager.Instance.StopCamera ();
		} else {
			CameraManager.Instance.StartCamera ();
		}
	}
}

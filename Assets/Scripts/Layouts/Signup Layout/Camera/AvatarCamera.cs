using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvatarCamera : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject image;
	public GameObject avatarMask;
	public RawImage rawimage;

	void Start() {
		CameraManager.Instance.LinqCameraWithTextura (rawimage, image, avatarMask);
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (CameraManager.Instance.GetCameraStatus()) {
			CameraManager.Instance.StopCamera ();
		} else {
			CameraManager.Instance.StartCamera ();
		}
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

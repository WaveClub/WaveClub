using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseCamera : MonoBehaviour, IPointerDownHandler {

	public void OnPointerDown(PointerEventData eventData) {
		CameraManager.Instance.StopCamera ();
	}
}

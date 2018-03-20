using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseObject : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject gameObjectForClose;

	public void OnPointerUp(PointerEventData eventData) {
		gameObjectForClose.SetActive (false);
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

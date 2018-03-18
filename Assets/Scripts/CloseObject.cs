using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseObject : MonoBehaviour, IPointerDownHandler {
	public GameObject gameObjectForClose;

	public void OnPointerDown(PointerEventData eventData) {
		gameObjectForClose.SetActive (false);
	}
}

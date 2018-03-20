using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSex : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject currentSex;
	public GameObject anotherSex;

	public void OnPointerUp(PointerEventData eventData) {
		currentSex.SetActive (true);
		anotherSex.SetActive (false);
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

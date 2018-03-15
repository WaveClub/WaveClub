using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSex : MonoBehaviour, IPointerDownHandler {
	public GameObject currentSex;
	public GameObject anotherSex;

	public void OnPointerDown(PointerEventData eventData) {
		currentSex.SetActive (true);
		anotherSex.SetActive (false);
	}
}

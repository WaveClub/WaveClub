using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSex : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject currentSex;
	public GameObject anotherSex;

	public void OnPointerUp(PointerEventData eventData) {
		if ("false".Equals(PlayerPrefs.GetString("isDragging"))){
			currentSex.SetActive (true);
			anotherSex.SetActive (false);
		}
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

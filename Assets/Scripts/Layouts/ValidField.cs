using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ValidField : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IBeginDragHandler {

	public Sprite validSprite;
	public InputField field;

	public void OnBeginDrag(PointerEventData data)
	{
		field.DeactivateInputField();
	}

	public void OnPointerUp(PointerEventData eventData) {
		field.image.sprite = validSprite;
	}
	public void OnPointerDown(PointerEventData eventData) {}
}

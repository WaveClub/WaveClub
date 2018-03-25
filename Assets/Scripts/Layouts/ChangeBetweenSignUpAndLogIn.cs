using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeBetweenSignUpAndLogIn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject signUp;
	public GameObject logIn;

	public void OnPointerUp(PointerEventData eventData){
		var active = signUp.activeSelf;
		signUp.SetActive (!active);
		logIn.SetActive (active);
		//Vector3 newSignUpCoordinates = new Vector3 (-Screen.width, 0, 0);
		signUp.transform.Translate(Vector3.left * 1000 * Time.deltaTime); //+= newSignUpCoordinates;
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

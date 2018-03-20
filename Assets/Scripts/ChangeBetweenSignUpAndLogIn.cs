using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeBetweenSignUpAndLogIn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject signUp;
	public GameObject logIn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerUp(PointerEventData eventData){
		var active = signUp.activeSelf;
		signUp.SetActive (!active);
		logIn.SetActive (active);
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeBetweenSignUpAndLogIn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject signUp;
	public GameObject logIn;

	private float endPos = Screen.width/2;	
	private float speed = -Screen.width/7;

	public void OnPointerUp(PointerEventData eventData){
		if (signUp.transform.position.x == Screen.width / 2) {
			signUp.transform.position += new Vector3 (Screen.width, 0, 0);
		} else {
			StartCoroutine (UpdatePath ());
		}
	}

	private IEnumerator UpdatePath()
	{
		while (signUp.transform.position.x > endPos) {
			if (signUp.transform.position.x + speed > endPos) {
				signUp.transform.position += new Vector3 (speed, 0, 0);
			} else {
				signUp.transform.position += new Vector3 (endPos - signUp.transform.position.x, 0, 0);
			}
			yield return null;
		}
	}


	public void OnPointerDown(PointerEventData eventData) {}
}



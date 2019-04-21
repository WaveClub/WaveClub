using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeBetweenSignUpAndLogIn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject signUp;
	public GameObject logIn;
	public GameObject Camera;
	public GameObject avatarIcon;
	public RawImage photoImage;

	private float endPos = Screen.width / 2;	
	private float speed = -Screen.width / 7;


	public void OnPointerUp(PointerEventData eventData) {
		Debug.Log ("buffer: " + PlayerPrefs.GetString ("BufferPhoto"));
		PlayerPrefs.SetString ("PhotoSaved", PlayerPrefs.GetString ("BufferPhoto"));
		Debug.Log ("photo: " + PlayerPrefs.GetString ("PhotoSaved"));
		Camera.transform.position += new Vector3 (Screen.width, 0, 0);
		Camera.SetActive (true);
				
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



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogOut  : MonoBehaviour, IPointerUpHandler
{
	public GameObject uiMenu;
	public GameObject logIn;


	private const string accessTokenKey = "access_token";

	public void OnPointerUp(PointerEventData eventData) {
		Debug.Log ("authorized before deleting " + PlayerPrefs.GetString(accessTokenKey));

		PlayerPrefs.DeleteKey (accessTokenKey);
		uiMenu.SetActive (false);
		logIn.SetActive (true);
		Debug.Log ("authorized after deleting " + PlayerPrefs.GetString(accessTokenKey));


	}
}



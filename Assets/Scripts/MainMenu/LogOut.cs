using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogOut  : MonoBehaviour, IPointerUpHandler
{
	public GameObject uiMenu;
	public GameObject logIn;


	private const string accessTokenKey = "AccessToken";

	public void OnPointerUp(PointerEventData eventData) {
		PlayerPrefs.DeleteKey (accessTokenKey);

		uiMenu.SetActive (false);
		logIn.SetActive (true);
	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLoading : MonoBehaviour {
	public GameObject loadingScreen;
	public GameObject logIn;
	public GameObject signUp;
	public GameObject uiMenu;

	private const int finishTime = 3;

	private const string accessTokenKey = "access_token";

	void Start () {
		signUp.transform.position += new Vector3 (Screen.width, 0, 0);
		signUp.SetActive (true);
	}

	void Update () {
		if (Time.time > finishTime) {
			loadingScreen.SetActive (false);

			if (PlayerPrefs.GetString (accessTokenKey) != null) {
				uiMenu.SetActive (true);
			} else {
				logIn.SetActive (true);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLoading : MonoBehaviour {
	public GameObject loadingScreen;
	public GameObject logIn;
	public GameObject signUp;

	private const int finishTime = 3;

	void Start () {
		signUp.transform.position += new Vector3 (Screen.width, 0, 0);
		signUp.SetActive (true);
	}

	void Update () {
		if (Time.time > finishTime) {
			loadingScreen.SetActive (false);
			logIn.SetActive (true);
		}
	}
}

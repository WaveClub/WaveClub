using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLoading : MonoBehaviour {
	public GameObject loadingScreen;
	public GameObject logIn;
	public GameObject signUp;

	private const int finishTime = 3;

	// Use this for initialization
	void Start () {
		Vector3 newSignUpCoordinates = new Vector3 (Screen.width, 0, 0);
		signUp.transform.position += newSignUpCoordinates;
//		Vector3 newSignUpCoordinates = new Vector3 (Screen.width + 10, 0, 0);
//		signUp.transform.position = Quaternion.Euler(newSignUpCoordinates;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > finishTime) {
			loadingScreen.SetActive (false);
			logIn.SetActive (true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLoading : MonoBehaviour {
	public GameObject loadingScreen;
	public GameObject logIn;

	private const int finishTime = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > finishTime) {
			loadingScreen.SetActive (false);
			logIn.SetActive (true);
		}
	}
}

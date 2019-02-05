using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLoading : MonoBehaviour {
	public GameObject loadingScreen;
	public GameObject logIn;
	public GameObject signUp;
	public GameObject uiMenu;


	[Header("UIMessage")]
	public GameObject UIMessageObject;
	public Text UIMessageText;

	[Header("UISpinner")]
	public GameObject UISpinner;

	private const int finishTime = 3;

	void Start () {
		signUp.transform.position += new Vector3 (Screen.width, 0, 0);
		signUp.SetActive (true);

		RequestHelper.UIMessageObject = UIMessageObject;
		RequestHelper.UIMessageText = UIMessageText;
		RequestHelper.UISpinner = UISpinner;
	}

	void Update () {
		if (Time.time > finishTime) {
			loadingScreen.SetActive (false);
			if (!System.String.IsNullOrEmpty(PlayerPrefs.GetString ("AccessToken"))) {
				uiMenu.SetActive (true);
			} else {
				logIn.SetActive (true);
			}
		}
	}
}

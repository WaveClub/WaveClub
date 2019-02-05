using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class SendLoginRequest : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	[Header("Credentials")]
	public InputField phoneField;
	public InputField passwordField;

	[Header("Sprites")]
	public Sprite incorrectFieldSprite;

	[Header("Game Objects")]
	public GameObject UIMenu;

	private string body;
	private string response;
	private const string method = "/Token/Authentication?";

	void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<UserIdentifier> (response);
			PlayerPrefs.SetString ("UserIdentifier", JsonUtility.ToJson(responseData));

			ClearField ();
			UIMenu.SetActive (true);

			response = null;
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (CheckField ())
			return;

		LoginRequestModel credentials = new LoginRequestModel (phoneField.text, passwordField.text);
		body = credentials.SaveToString();

		StartCoroutine (RequestHelper.GetRequest (method + "phoneNumber=" + phoneField.text + "&password=" + passwordField.text, (result) => response = result));
	}

	public void OnPointerDown(PointerEventData eventData) {}

	private void ClearField() {
		phoneField.text = passwordField.text = string.Empty;
	}

	private bool CheckField() {
		if (phoneField.text == string.Empty)
			phoneField.image.sprite = incorrectFieldSprite;
		
		if (passwordField.text == string.Empty)
			passwordField.image.sprite = incorrectFieldSprite;

		return phoneField.text == string.Empty || passwordField.text == string.Empty;
	}
}

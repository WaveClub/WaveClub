using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendLoginRequest : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	[Header("Credentials")]
	public InputField phoneField;
	public InputField passwordField;
	[Header("Sprites")]
	public Sprite incorrectFieldSprite;
	[Header("Game Objects")]
	public GameObject spinner;
	public GameObject mainMenu;

	private string body;
	private string response;
	private const string method = "/login";

	void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<LoginResponseModel> (response);
			spinner.SetActive (false);
			switch (responseData.status_code) {

			case (int) StatusCode.INVALID_CREDENTIALS:
				phoneField.image.sprite = incorrectFieldSprite;
				passwordField.image.sprite = incorrectFieldSprite;
				passwordField.text = string.Empty;
				break;

			case (int) StatusCode.OK:
				Debug.Log (responseData.access_token);
				PlayerPrefs.SetString ("access_token", responseData.access_token);
				mainMenu.SetActive (true);
				break;

			}

			response = null;
		}
	}

	public bool checkField() {
		if (phoneField.text == string.Empty)
			phoneField.image.sprite = incorrectFieldSprite;
		if (passwordField.text == string.Empty)
			passwordField.image.sprite = incorrectFieldSprite;

		if (phoneField.text == string.Empty || passwordField.text == string.Empty)
			return true;
		return false;
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (checkField ())
			return;

		LoginRequestModel credentials = new LoginRequestModel (phoneField.text, passwordField.text);
		body = credentials.SaveToString();
		spinner.SetActive (true);

		StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendLoginRequest : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public InputField phoneField;
	public InputField passwordField;
	public Sprite incorrectFieldSprite;

	public GameObject message;
	public Text messageText;

	private string body;
	private string response;
	private const string method = "/login";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<LoginResponseModel> (response);
			message.SetActive (true);
			switch (responseData.status_code) {

			case (int) StatusCode.INVALID_CREDENTIALS:
				messageText.text = "Не правильный логин или пароль";
				break;

			case (int) StatusCode.OK:
				Debug.Log (responseData.access_token);
				PlayerPrefs.SetString ("access_token", responseData.access_token);
				messageText.text = "Привет, " + responseData.account.name;
				break;

			}

			response = null;
		}
	}

	public bool checkField() {
		if (phoneField.text == "")
			phoneField.image.sprite = incorrectFieldSprite;
		if (passwordField.text == "")
			passwordField.image.sprite = incorrectFieldSprite;

		if (phoneField.text == "" || passwordField.text == "")
			return true;
		return false;
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (checkField ())
			return;


		LoginRequestModel credentials = new LoginRequestModel (phoneField.text, passwordField.text);
		body = credentials.SaveToString();

		StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

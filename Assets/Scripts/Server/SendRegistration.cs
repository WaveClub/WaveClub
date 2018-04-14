using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendRegistration : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public InputField loginField;
	public InputField nameField;
	public InputField passwordField;
	public InputField confirmPasswordField;
	public GameObject male;
    public GameObject codeConfirm;

    public Sprite incorrectFieldSprite;

	public GameObject UIMessage;
	public Text UIMessageText;

	private string body;
	private string response;
	private const string method = "/registration";

	void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<RegistrationResponseModel> (response);

			switch (responseData.status_code) {
				case (int) StatusCode.USER_EXISTS:
                    ShowMessage ("User with this phone number already exists!");
					break;
				case (int) StatusCode.OK:
					// todo object on scene
					SendAcceptCode (responseData);
					break;
			}

			response = null;
		}
	}

	public bool CheckField() {
		if (passwordField.text == "")
			passwordField.image.sprite = incorrectFieldSprite;
		if (confirmPasswordField.text == "")
			confirmPasswordField.image.sprite = incorrectFieldSprite;
		if (loginField.text == "")
			loginField.image.sprite = incorrectFieldSprite;
		if (nameField.text == "")
			nameField.image.sprite = incorrectFieldSprite;

		if (passwordField.text == "" || confirmPasswordField.text == "" || 
			loginField.text == "" || nameField.text == "") {
			return true;
		}

		if (passwordField.text != confirmPasswordField.text) {
			confirmPasswordField.image.sprite = incorrectFieldSprite;
			return true;
		}

		return false;
	}

	public void SendAcceptCode(RegistrationResponseModel model) {
        codeConfirm.SetActive(true);
    }

	public void ShowMessage(string message) {
		UIMessage.SetActive (true);
		UIMessageText.text = message;
	}

	public void OnPointerUp(PointerEventData eventData) {
		string sex = male.activeSelf ? "male" : "female";

		if (CheckField ())
			return;

		RegistrationRequestModel credentials = new RegistrationRequestModel(loginField.text, nameField.text, passwordField.text, sex);

        body = credentials.SaveToString();
        
		StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

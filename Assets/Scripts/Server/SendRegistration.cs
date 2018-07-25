using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendRegistration : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	[Header("Fields")]
	public InputField loginField;
	public InputField nameField;
	public InputField passwordField;
	public InputField confirmPasswordField;
	[Header("Sprites")]
	public Sprite incorrectFieldSprite;
	[Header("GameObjects")]
	public GameObject male;
	public GameObject spinner;
    public GameObject codeConfirm;

	private string body;
	private string response;
	private const string method = "/registration";

    void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<RegistrationResponseModel> (response);
			spinner.SetActive (false);
			switch (responseData.status_code) {
				case (int) StatusCode.USER_EXISTS:
                    // ShowMessage ("User with this phone number already exists!");
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
		if (passwordField.text == string.Empty)
			passwordField.image.sprite = incorrectFieldSprite;
		if (confirmPasswordField.text == string.Empty)
			confirmPasswordField.image.sprite = incorrectFieldSprite;
		if (loginField.text == string.Empty)
			loginField.image.sprite = incorrectFieldSprite;
		if (nameField.text == string.Empty)
			nameField.image.sprite = incorrectFieldSprite;

		if (passwordField.text == string.Empty || confirmPasswordField.text == string.Empty || 
			loginField.text == string.Empty || nameField.text == string.Empty) {
			return true;
		}

		if (passwordField.text != confirmPasswordField.text) {
			confirmPasswordField.image.sprite = incorrectFieldSprite;
			return true;
		}

        if (StaticObject.PhotoFromCamera == null) {
            //TODO return window with text = "Please make photo!";
            return true;
        }

		return false;
	}

	public void SendAcceptCode(RegistrationResponseModel model) {
        SendSMSCode.registrationResponseModel = model;
        codeConfirm.SetActive(true);
    }

	/* public void ShowMessage(string message) {
		UIMessage.SetActive (true);
		UIMessageText.text = message;
	} */

	public void OnPointerUp(PointerEventData eventData) {
		if ("false".Equals (PlayerPrefs.GetString ("isDragging"))) {
			string sex = male.activeSelf ? "male" : "female";

			if (CheckField ())
				return;

			RegistrationRequestModel credentials = new RegistrationRequestModel(loginField.text, nameField.text, passwordField.text, sex, StaticObject.RawImageToBase64String(StaticObject.PhotoFromCamera));
			body = credentials.SaveToString();
			spinner.SetActive (true);

			StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
		}

	}
	public void OnPointerDown(PointerEventData eventData) {}
}

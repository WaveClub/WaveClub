using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

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
	public GameObject codeConfirm;

	private string body;
	private string response;
	private const string method = "/Token/Registration";

    void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<BaseResponse> (response);

			PlayerPrefs.SetString ("PhoneNumber", loginField.text);
			codeConfirm.SetActive (true);

			ClearField ();
			response = null;
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		if ("false".Equals (PlayerPrefs.GetString ("isDragging"))) {
			bool sex = male.activeSelf;

			if (CheckField ())
				return;

			RegistrationRequestModel credentials = new RegistrationRequestModel(loginField.text, nameField.text, passwordField.text, sex, StaticObject.RawImageToBase64String(StaticObject.PhotoFromCamera));
			body = credentials.SaveToString();

			StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
		}

	}

	public void OnPointerDown(PointerEventData eventData) {}

	private void ClearField() {
		passwordField.text = confirmPasswordField.text = loginField.text = nameField.text = string.Empty;
	}

	private bool CheckField() {
		if (passwordField.text == string.Empty)
			passwordField.image.sprite = incorrectFieldSprite;

		if (confirmPasswordField.text == string.Empty)
			confirmPasswordField.image.sprite = incorrectFieldSprite;

		if (loginField.text == string.Empty)
			loginField.image.sprite = incorrectFieldSprite;

		if (nameField.text == string.Empty)
			nameField.image.sprite = incorrectFieldSprite;

		if (passwordField.text != confirmPasswordField.text) {
			confirmPasswordField.image.sprite = incorrectFieldSprite;
		}

		/*if (StaticObject.PhotoFromCamera == null) {
            //TODO return window with text = "Please make photo!";
            return true;
        }*/

		return passwordField.text == string.Empty || confirmPasswordField.text == string.Empty || 
			loginField.text == string.Empty || nameField.text == string.Empty || passwordField.text != confirmPasswordField.text;
	}
}

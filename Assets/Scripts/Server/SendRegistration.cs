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
<<<<<<< HEAD
	[Header("Sprites")]
	public Sprite incorrectFieldSprite;
	[Header("GameObjects")]
	public GameObject male;
	public GameObject spinner;
    public GameObject codeConfirm;
=======
	public GameObject male;
    public GameObject codeConfirm;

    public Sprite incorrectFieldSprite;

	public GameObject UIMessage;
	public Text UIMessageText;
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b

	private string body;
	private string response;
	private const string method = "/registration";

    void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<RegistrationResponseModel> (response);
<<<<<<< HEAD
			spinner.SetActive (false);
			switch (responseData.status_code) {
				case (int) StatusCode.USER_EXISTS:
                    // ShowMessage ("User with this phone number already exists!");
=======

			switch (responseData.status_code) {
				case (int) StatusCode.USER_EXISTS:
                    ShowMessage ("User with this phone number already exists!");
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b
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
<<<<<<< HEAD
		if (passwordField.text == string.Empty)
=======
		if (passwordField.text == "")
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b
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

<<<<<<< HEAD
	/* public void ShowMessage(string message) {
		UIMessage.SetActive (true);
		UIMessageText.text = message;
	} */
=======
	public void ShowMessage(string message) {
		UIMessage.SetActive (true);
		UIMessageText.text = message;
	}
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b

	public void OnPointerUp(PointerEventData eventData) {
		if ("false".Equals (PlayerPrefs.GetString ("isDragging"))) {
			string sex = male.activeSelf ? "male" : "female";

			if (CheckField ())
				return;

			RegistrationRequestModel credentials = new RegistrationRequestModel(loginField.text, nameField.text, passwordField.text, sex, StaticObject.RawImageToBase64String(StaticObject.PhotoFromCamera));
<<<<<<< HEAD
			body = credentials.SaveToString();
			spinner.SetActive (true);

			StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
		}

=======

			body = credentials.SaveToString();

			StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
		}

>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b
	}
	public void OnPointerDown(PointerEventData eventData) {}
}

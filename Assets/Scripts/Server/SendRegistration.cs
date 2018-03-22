﻿using System.Collections;
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
	public Sprite incorrectFieldSprite;

	public GameObject message;
	public Text messageText;

	private string body;
	private string response;
	private const string method = "/registration";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (response != null) {
			var responseData = JsonUtility.FromJson<BaseResponse> (response);

			message.SetActive (true);
			switch (responseData.status_code) {

			case (int) StatusCode.USER_EXISTS:
				messageText.text = "Пользователь с таким логином уже существует";
				break;

			case (int) StatusCode.OK:
				messageText.text = "Регистрация успешна";
				break;

			}

			response = null;
		}
	}

	public bool checkField() {
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

	public void OnPointerUp(PointerEventData eventData) {
		string sex = male.activeSelf ? "male" : "female";

		if (checkField ())
			return;

		RegistrationRequestModel credentials = new RegistrationRequestModel(loginField.text, nameField.text, passwordField.text, sex);
		body = credentials.SaveToString();

		StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
	}

	public void OnPointerDown(PointerEventData eventData) {}
}
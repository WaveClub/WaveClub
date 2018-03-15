using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendLoginRequest : MonoBehaviour, IPointerDownHandler {
	public InputField phoneField;
	public InputField passwordField;

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
				messageText.text = "Привет хз кто, Влад, добавь имя";
				break;

			}

			response = null;
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		LoginRequestModel credentials = new LoginRequestModel (phoneField.text, passwordField.text);
		body = credentials.SaveToString();

		StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
	}
}

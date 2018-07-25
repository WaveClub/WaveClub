using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendSMSCode : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	[Header("Fields")]
    public InputField codeConfirmField;
	[Header("Sprites")]
	public Sprite incorrectFieldSprite;
	[Header("Game Objects")]
	public GameObject spinner;
	public GameObject logIn;
	public GameObject signUp;
	public GameObject codeConfirm;

    private string body;
    private string response;
    private const string method = "/acceptcode";

    public static RegistrationResponseModel registrationResponseModel;

    void Update () {
        if (response != null)
        {
            var responseData = JsonUtility.FromJson<RegistrationResponseModel>(response);
			spinner.SetActive (false);
            switch (responseData.status_code)
            {
                case (int)StatusCode.USER_EXISTS:
                    // ShowMessage("User with this phone number already exists!");
                    break;
				case (int)StatusCode.OK:
					logIn.SetActive (true);
					signUp.SetActive (false);
					codeConfirm.SetActive (false);
                    break;
            }
            response = null;
        }
    }

    /* public void ShowMessage(string message)
    {
        UIMessage.SetActive(true);
        UIMessageText.text = message;
    } */

    public bool CheckField() {
		if (codeConfirmField.text == string.Empty) {
			codeConfirmField.image.sprite = incorrectFieldSprite;
            return true;
        }
        return false;
    } 

    public void OnPointerUp(PointerEventData eventData)
    {
        if (CheckField())
            return;

		CodeConfirmRequestModel credentials = new CodeConfirmRequestModel(registrationResponseModel.user_id, codeConfirmField.text);
        body = credentials.SaveToString();
		spinner.SetActive (true);

        StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
    }

    public void OnPointerDown(PointerEventData eventData) { }
}




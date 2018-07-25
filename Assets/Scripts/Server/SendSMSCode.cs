using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendSMSCode : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
<<<<<<< HEAD
	[Header("Fields")]
    public InputField codeConfirmField;
	[Header("Sprites")]
	public Sprite incorrectFieldSprite;
	[Header("Game Objects")]
	public GameObject spinner;
	public GameObject logIn;
	public GameObject signUp;
	public GameObject codeConfirm;
=======

    public InputField codeConfirm;
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b

    private string body;
    private string response;
    private const string method = "/acceptcode";

<<<<<<< HEAD
    public static RegistrationResponseModel registrationResponseModel;

=======
    public Sprite incorrectFieldSprite;

    public GameObject UIMessage;
    public Text UIMessageText;
    public static RegistrationResponseModel registrationResponseModel;

    // Update is called once per frame
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b
    void Update () {
        if (response != null)
        {
            var responseData = JsonUtility.FromJson<RegistrationResponseModel>(response);
<<<<<<< HEAD
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
=======

            switch (responseData.status_code)
            {
                case (int)StatusCode.USER_EXISTS:
                    ShowMessage("User with this phone number already exists!");
                    break;
                case (int)StatusCode.OK:
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b
                    break;
            }
            response = null;
        }
    }

<<<<<<< HEAD
    /* public void ShowMessage(string message)
    {
        UIMessage.SetActive(true);
        UIMessageText.text = message;
    } */

    public bool CheckField() {
		if (codeConfirmField.text == string.Empty) {
			codeConfirmField.image.sprite = incorrectFieldSprite;
=======
    public void ShowMessage(string message)
    {
        UIMessage.SetActive(true);
        UIMessageText.text = message;
    }

    public bool CheckField() {
        if (codeConfirm.text == "") {
            codeConfirm.image.sprite = incorrectFieldSprite;
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b
            return true;
        }
        return false;
    } 

    public void OnPointerUp(PointerEventData eventData)
    {
<<<<<<< HEAD
        if (CheckField())
            return;

		CodeConfirmRequestModel credentials = new CodeConfirmRequestModel(registrationResponseModel.user_id, codeConfirmField.text);
        body = credentials.SaveToString();
		spinner.SetActive (true);
=======
        
        if (CheckField())
            return;

        CodeConfirmRequestModel credentials = new CodeConfirmRequestModel(registrationResponseModel.user_id, codeConfirm.text);
        body = credentials.SaveToString();
>>>>>>> b56f826ba21ced46a4cc912a776f8ca9bd22339b

        StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
    }

    public void OnPointerDown(PointerEventData eventData) { }
}




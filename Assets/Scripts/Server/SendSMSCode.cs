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
	public GameObject codeConfirm;
	public GameObject UIMenu;

    private string response;
    private const string method = "/Token/Verification";

    void Update () {
        if (response != null)
        {
			VerificationResponseModel responseData = JsonUtility.FromJson<VerificationResponseModel>(response);
			PlayerPrefs.SetString ("UserIdentifier", JsonUtility.ToJson(responseData.User));

			codeConfirmField.text = string.Empty;
			codeConfirm.SetActive (false);
			UIMenu.SetActive (true);
            response = null;
        }
    }

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

		int verificationCode;
		if (int.TryParse (codeConfirmField.text, out verificationCode)) {
			CodeConfirmRequestModel credentials = new CodeConfirmRequestModel (PlayerPrefs.GetString ("PhoneNumber"), verificationCode);
			StartCoroutine (RequestHelper.PostRequest (credentials.SaveToString (), method, (result) => response = result));
		} else {
			codeConfirmField.image.sprite = incorrectFieldSprite;
		}
    }

    public void OnPointerDown(PointerEventData eventData) { }
}




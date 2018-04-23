using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendSMSCode : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    public InputField codeConfirm;

    private string body;
    private string response;
    private const string method = "/acceptcode";

    public Sprite incorrectFieldSprite;

    public GameObject UIMessage;
    public Text UIMessageText;
    public static RegistrationResponseModel registrationResponseModel;

    // Update is called once per frame
    void Update () {
        if (response != null)
        {
            var responseData = JsonUtility.FromJson<RegistrationResponseModel>(response);

            switch (responseData.status_code)
            {
                case (int)StatusCode.USER_EXISTS:
                    ShowMessage("User with this phone number already exists!");
                    break;
                case (int)StatusCode.OK:
                    break;
            }
            response = null;
        }
    }

    public void ShowMessage(string message)
    {
        UIMessage.SetActive(true);
        UIMessageText.text = message;
    }

    public bool CheckField() {
        if (codeConfirm.text == "") {
            codeConfirm.image.sprite = incorrectFieldSprite;
            return true;
        }
        return false;
    } 

    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (CheckField())
            return;

        CodeConfirmRequestModel credentials = new CodeConfirmRequestModel(registrationResponseModel.user_id, codeConfirm.text);
        body = credentials.SaveToString();

        StartCoroutine(RequestHelper.PostRequest(body, method, (result) => response = result));
    }

    public void OnPointerDown(PointerEventData eventData) { }
}




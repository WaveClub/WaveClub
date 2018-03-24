using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpResource : MonoBehaviour {

    public Text loginFieldInput;
    public Text nameFieldInput;
    public Text passwordFieldInput;
    public Text photoUpload;
    public Text registrationButton;
    public Text confirmPasswordFieldInput;
    public Text selectSexText;

    private const string xpath = "sign-up";
	private Dictionary<string, string> config;

	// Use this for initialization
	void Start () {
		LoadLocalization ();
	}

	public void LoadLocalization() {
		config = LocalizationManager.getConfig (xpath);
        loginFieldInput.text = config["login-field-input"];
        nameFieldInput.text = config["name-field-input"];
        photoUpload.text = config["photo-upload"];
        registrationButton.text = config["registration-button.text"];
        passwordFieldInput.text = config["password-field-input"];
        confirmPasswordFieldInput.text = config["confirm-password-field-input"];
        selectSexText.text = config["select-sex-text"];
    }
}

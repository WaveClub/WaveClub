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

    private const string xpath = "sign_up_section";
	private Dictionary<string, string> config;

	// Use this for initialization
	void Start () {
		LoadLocalization ();
	}

	public void LoadLocalization() {
		config = LocalizationManager.getConfig (xpath);
        loginFieldInput.text = config["login_field_input"];
        nameFieldInput.text = config["name_field_input"];
        photoUpload.text = config["photo_upload"];
        registrationButton.text = config["registration_button"];
        passwordFieldInput.text = config["password_field_input"];
        confirmPasswordFieldInput.text = config["confirm_password_field_input"];
        selectSexText.text = config["select_sex_text"];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUpResource : MonoBehaviour {
	public Text confirm;
	public Text confirmPassword;
	public Text createPassword;
	public Text selectYourSex;
	public Text yourLogin;
	public Text yourName;
	public Text uploadPhoto;

    private const string xpath = "sign_up_section";

	void Start () {
		LoadLocalization ();
	}

	public void LoadLocalization() {
		Dictionary<string, string> config = LocalizationManager.getConfig (xpath);

		confirm.text = config ["confirm"];
		confirmPassword.text = config ["confirm_password"];
		createPassword.text = config ["create_password"];
		selectYourSex.text = config ["select_your_sex"];
		yourLogin.text = config ["your_login"];
		yourName.text = config ["your_name"];
		uploadPhoto.text = config ["upload_photo"];
    }
}

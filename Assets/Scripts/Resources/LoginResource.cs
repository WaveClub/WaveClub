using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginResource : MonoBehaviour {
	public Text welcomeText;
	public Text passwordForgottenest;
	public Text login;
	public Text signUp;
    public Text passwordField;
    public Text loginField;
    private const string xpath = "login_section";
	private Dictionary<string, string> config;

	// Use this for initialization
	void Start () {
		LoadLocalization ();
	}

	public void LoadLocalization() {
		config = LocalizationManager.getConfig (xpath);
        welcomeText.text = config["welcome"];
		passwordForgottenest.text = config ["password_forgotten"];
		signUp.text = config ["signup"];
		login.text = config ["login"];
        loginField.text = config["login_field"];
        passwordField.text = config["password_field"];
    }
}

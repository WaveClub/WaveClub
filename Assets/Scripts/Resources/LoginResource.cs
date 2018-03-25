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
    private const string xpath = "login";
	private Dictionary<string, string> config;

	// Use this for initialization
	void Start () {
		LoadLocalization ();
	}

	public void LoadLocalization() {
		config = LocalizationManager.getConfig (xpath);

		Debug.Log (config.Where(x => x.Key.ToString().CompareTo("welcome") == 0).FirstOrDefault().Value);
        welcomeText.text = config["welcome"];
		passwordForgottenest.text = config ["password-forgotten"];
		signUp.text = config ["signup"];
		login.text = config ["login-1"];
        loginField.text = config["login-field"];
        passwordField.text = config["password-field"];
    }
}

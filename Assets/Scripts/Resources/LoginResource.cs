using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginResource : MonoBehaviour {
	public Text forgottenPassword;
	public Text signIn;
	public Text signUp;
	public Text yourLogin;
	public Text yourPassword;
	public Text welcomeToWaveclub;

	private const string xpath = "login_section";
	private string curLanguage;

	void Start () {
		curLanguage = LocalizationManager.Instance.LanguageCode;
		LoadLocalization ();
	}

	void Update () {
		if (curLanguage != LocalizationManager.Instance.LanguageCode) {
			curLanguage = LocalizationManager.Instance.LanguageCode;
			this.LoadLocalization ();
		}
	}

	public void LoadLocalization() {
		Dictionary<string, string> config = LocalizationManager.getConfig (xpath);

		forgottenPassword.text = config["forgotten_password"];
		signIn.text = config ["sign_in"];
		signUp.text = config ["sign_up"];
		yourLogin.text = config ["your_login"];
		yourPassword.text = config ["your_password"];
		welcomeToWaveclub.text = config ["welcome_to_waveclub"];
    }
}

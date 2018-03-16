using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogIn : MonoBehaviour {
	public Text welcomeText;

	private const string xpath = "login";
	private Dictionary<string, string> config;

	// Use this for initialization
	void Start () {
		LoadLocalization ();
	}

	// Добавить привязку к полям?
	public void LoadLocalization() {
		config = LocalizationManager.getConfig (xpath);
		welcomeText.text = config["welcome"];
	}
}

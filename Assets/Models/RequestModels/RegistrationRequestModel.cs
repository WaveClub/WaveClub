using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationRequestModel {
    public string phoneNumber;
    public string password;
    public string name;
    public string sex;
    public string lang;

	public RegistrationRequestModel(
		string phone,
		string name,
		string pass,
		string sex
	) {
		this.phoneNumber = phone;
		this.password = pass;
		this.name = name;
		this.sex = sex;
		this.lang = LocalizationManager.Instance.LanguageCode;
	}

	public string SaveToString() {
		return JsonUtility.ToJson (this);
	}
}

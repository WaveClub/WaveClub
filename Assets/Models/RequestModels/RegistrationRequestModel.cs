using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationRequestModel {
    public string phone;
    public string password;
    public string name;
    public string sex;
    public string lang;
    public string picture;

	public RegistrationRequestModel(
		string phone,
		string name,
		string pass,
		string sex,
        string picture
	) {
		this.phone = phone;
		this.password = pass;
		this.name = name;
		this.sex = sex;
		this.lang = LocalizationManager.Instance.LanguageCode;
        this.picture = picture;
	}

	public string SaveToString() {
		return JsonUtility.ToJson (this);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationRequestModel {
	public string phoneNumber { get; set; }
	public string password { get; set; }
	public string name { get; set; }
	public string sex { get; set; }
	public string lang { get; set; }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationRequestModel {
	public string PhoneNumber;
	public string Password;
	public string Name;
	public bool Sex;
	public string Language;
    public string Picture;

	public RegistrationRequestModel(
		string phone,
		string name,
		string pass,
		bool sex,
        string picture
	) {
		PhoneNumber = phone;
		Password = pass;
		Name = name;
		Sex = sex;
		Language = LocalizationManager.Instance.LanguageCode;
		Picture = picture;
	}

	public string SaveToString() {
		return JsonUtility.ToJson (this);
	}
}

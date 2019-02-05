using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRequestModel {
	public string PhoneNumber;
	public string Password;

	public LoginRequestModel(string phoneNumber, string pass) {
		PhoneNumber = phoneNumber;
		Password = pass;
	}

	public string SaveToString() {
		return JsonUtility.ToJson (this);
	}
}

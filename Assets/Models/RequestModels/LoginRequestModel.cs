using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRequestModel {
	public string phoneNumber;
	public string password;

	public LoginRequestModel(string phone, string pass) {
		phoneNumber = phone;
		password = pass;
	}

	public string SaveToString() {
		return JsonUtility.ToJson (this);
	}
}

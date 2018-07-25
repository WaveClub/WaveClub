using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRequestModel {
	public string phone;
	public string password;

	public LoginRequestModel(string phoneNumber, string pass) {
		phone = phoneNumber;
		password = pass;
	}

	public string SaveToString() {
		return JsonUtility.ToJson (this);
	}
}

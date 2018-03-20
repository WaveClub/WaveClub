using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoginResponseModel : BaseResponse {

	public string access_token;
	public AccountModel account;
}

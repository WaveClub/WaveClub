using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CodeConfirmRequestModel {
	public string PhoneNumber;
    public int VerificationCode;

	public CodeConfirmRequestModel(string phoneNumber, int verificationCode) {
		PhoneNumber = phoneNumber;
		VerificationCode = verificationCode;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CodeConfirmRequestModel {
    public int user_id;
    public string code;

    public CodeConfirmRequestModel(int user_id, string code) {
        this.user_id = user_id;
        this.code = code;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

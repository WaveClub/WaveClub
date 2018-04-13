using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CodeConfirmRequestModel {
    public string userId { get; set; }
    public string сode { get; set; }

    public CodeConfirmRequestModel(string userId, string code) {
        this.userId = userId;
        this.сode = code;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

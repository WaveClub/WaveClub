using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public static class StaticObject
{
    public static RawImage PhotoFromCamera;

    public static String RawImageToBase64String(RawImage image)
    {
        Texture2D tex = image.texture as Texture2D;
        byte[] bytes = tex.EncodeToPNG();
        string encodedText = Convert.ToBase64String(bytes);
        return encodedText;
    }

}
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseCamera : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public RawImage photoImage;
	public Vector3 rotationObject;

	void Start() {
		#if UNITY_IPHONE
			rotationObject = new Vector3 (0, 0, -90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif

		#if UNITY_ANDROID
			rotationObject = new Vector3 (0, 0, 90);
			transform.rotation = Quaternion.Euler (rotationObject);
		#endif
	}

    public void UpLoadPhotoFromPlayerPrefs(String str)
    {
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(Convert.FromBase64String(PlayerPrefs.GetString("PhotoSaved")));
        tex.Apply();
        this.photoImage.texture = tex;
    }

    public void OnPointerUp(PointerEventData eventData) {
		CameraManager.Instance.GetPhoto (photoImage);
        StaticObject.PhotoFromCamera = photoImage;
        PlayerPrefs.SetString("PhotoSaved", StaticObject.RawImageToBase64String(photoImage));
        CameraManager.Instance.StopCamera ();
    }

	public void OnPointerDown(PointerEventData eventData) {}
}

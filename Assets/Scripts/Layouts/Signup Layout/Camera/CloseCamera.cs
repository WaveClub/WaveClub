using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseCamera : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject cameraObject;
	public RawImage photoImage;
	public Vector3 rotationObject;
	public GameObject photo;

	void Start() {
		#if UNITY_IPHONE
			rotationObject = new Vector3 (0, 0, -90);
			cameraObject.transform.rotation = Quaternion.Euler (rotationObject);
		#endif

		#if UNITY_ANDROID
			rotationObject = new Vector3 (0, 0, 90);
			cameraObject.transform.rotation = Quaternion.Euler (rotationObject);
			cameraObject.transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y* -1, transform.localScale.z);
		#endif
	}

	public void UpLoadPhotoFromPlayerPrefs(String str)
	{
		Texture2D tex = new Texture2D(1, 1);
		tex.LoadImage(Convert.FromBase64String(PlayerPrefs.GetString("PhotoSaved")));
		tex.Resize (Screen.width / 2, Screen.height/2);
		tex.Apply();
		this.photoImage.texture = tex;
	}

	public void OnPointerUp(PointerEventData eventData) {
		CameraManager.Instance.GetPhoto (photoImage);
		StaticObject.PhotoFromCamera = photoImage;
		if (SystemInfo.deviceType == DeviceType.Desktop && PlayerPrefs.GetString ("PhotoSaved") == null) { // Bullshit but works
			PlayerPrefs.SetString("PhotoSaved", StaticObject.RawImageToBase64String(photoImage));
		}
		correctAvatar ();
		CameraManager.Instance.StopCamera ();
	}

	public void OnPointerDown(PointerEventData eventData) {}
	private void correctAvatar() {
		RectTransform photoObject = photo.GetComponent<RectTransform> ();
		float oldWith = photoObject.rect.width;
		photoObject.sizeDelta = new Vector2 (photoObject.rect.height * Screen.height / Screen.width, photoObject.sizeDelta.y);
		//photoObject.rect.width = (photoObject.rect.height * Screen.width / Screen.height);
		photo.transform.position -= new Vector3 (0, (photoObject.rect.width - oldWith) / 2, 0);
	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
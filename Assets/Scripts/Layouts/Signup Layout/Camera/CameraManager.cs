using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager {
	private WebCamTexture Camera;
	private GameObject Texture;
	private GameObject AvatarMask;

	private static CameraManager instance;
	public static CameraManager Instance {
		get {
			if (instance == null)
				instance = new CameraManager ();
			return instance;
		}
	}

	private CameraManager() {
		WebCamDevice? device = WebCamTexture.devices.FirstOrDefault (d => d.isFrontFacing);
		if (device.HasValue) {
			Camera = new WebCamTexture (device.Value.name, Screen.height, Screen.width);
			Camera.filterMode = FilterMode.Point;
		}
	}

	public void LinqCameraWithTextura(RawImage image, GameObject texture, GameObject mask) {
		if (Camera == null)
			return;
		image.texture = Camera;
		image.material.mainTexture = Camera;
		Texture = texture;
		AvatarMask = mask;
	}

	public void StartCamera() {
		if (Camera == null || Camera.isPlaying)
			return;
		Camera.Play ();
		Texture.SetActive (true);
	}

	public void StopCamera() {
		if (Camera == null || !Camera.isPlaying)
			return;
		Camera.Stop ();

		AvatarMask.SetActive (true);
		Texture.SetActive (false);
	}

	public bool GetCameraStatus() {
		if (Camera == null)
			return false;
		return Camera.isPlaying;
	}

	public void GetPhoto(RawImage image) {
		var texture = new Texture2D (Camera.width, Camera.height);
		texture.SetPixels (Camera.GetPixels ());

		texture.Apply ();

		image.texture = texture;
	}
}

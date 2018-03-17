using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager {
	private WebCamTexture Camera;
	private GameObject Texture;

	private static CameraManager instance;
	public static CameraManager Instance {
		get {
			if (instance == null)
				instance = new CameraManager ();
			return instance;
		}
	}

	private CameraManager() {
		WebCamDevice[] devices = WebCamTexture.devices;

		Camera = new WebCamTexture (devices.LastOrDefault ().name);
		Camera.filterMode = FilterMode.Point;
	}

	public void LinqCameraWithTextura(RawImage image, GameObject texture) {
		image.texture = Camera;
		image.material.mainTexture = Camera;
		Texture = texture;
	}

	public void StartCamera() {
		if (Camera.isPlaying)
			return;
		Camera.Play ();
		Texture.SetActive (true);
	}

	public void StopCamera() {
		if (!Camera.isPlaying)
			return;
		Camera.Stop ();
		Texture.SetActive (false);
	}

	public bool getCameraStatus() {
		return Camera.isPlaying;
	}
}

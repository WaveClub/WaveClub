using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvatarCamera : MonoBehaviour, IPointerDownHandler {
	public GameObject image;
	public RawImage rawimage;

	private WebCamTexture web;

	void Start() {
		WebCamDevice[] devices = WebCamTexture.devices;

		web = new WebCamTexture ();
		web.deviceName = devices.FirstOrDefault ().name;
		rawimage.texture = web;
		rawimage.material.mainTexture = web;
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (web.isPlaying) {
			web.Stop ();
			image.SetActive (false);
		} else {
			web.Play ();
			image.SetActive (true);
		}
	}
}

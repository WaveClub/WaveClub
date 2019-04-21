using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvatarCamera : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public GameObject image;
	public GameObject avatarMask;
	public RawImage rawimage;

	private float endPos = Screen.width / 2;	
	private float speed = -Screen.width / 7;

	void Start() {
		CameraManager.Instance.LinqCameraWithTextura (rawimage, image, avatarMask);
		PlayerPrefs.SetString ("BufferPhoto", "");
	}

	public void OnPointerUp(PointerEventData eventData) {
		if ("false".Equals (PlayerPrefs.GetString ("isDragging"))) {
			if (CameraManager.Instance.GetCameraStatus ()) {
				image.SetActive (false);
				CameraManager.Instance.StopCamera ();
			} else {
				CameraManager.Instance.StartCamera ();
			
				if (image.transform.position.x == Screen.width / 2) {
					image.transform.position += new Vector3 (Screen.width, 0, 0);
				} else {
						
					StartCoroutine (UpdatePath ());
				}
			}
		}
	}

	private IEnumerator UpdatePath()
	{
		while (image.transform.position.x > endPos) {
			if (image.transform.position.x + speed > endPos) {
				image.transform.position += new Vector3 (speed, 0, 0);
			} else {
				image.transform.position += new Vector3 (endPos - image.transform.position.x, 0, 0);
			}
			yield return null;
		}
	}

	public void OnPointerDown(PointerEventData eventData) {}
}

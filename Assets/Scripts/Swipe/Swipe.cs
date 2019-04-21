using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Swipe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

	public GameObject signUp;
	public RawImage photoImage;
	public Sprite avatar;
	public GameObject avatarIcon;
	Vector2 _lastPosition = Vector2.zero;
	Vector2 startDragPosition = Vector2.zero;


	private float speed = Screen.width/7;
	private bool signUpToTheRight;

	public Events.Vector2 OnSwipeStart = new Events.Vector2();
	public Events.Vector2 OnSwipeEnd = new Events.Vector2();
	public Events.Vector2 OnSwipe = new Events.Vector2();
	Vector2 direction;
	void Start() {
	}

	public void OnBeginDrag(PointerEventData eventData) {
		PlayerPrefs.SetString ("isDragging", "true");
		_lastPosition = eventData.position;
		startDragPosition = eventData.position;
		OnSwipeStart.Invoke(eventData.position);


	}

	public void OnEndDrag(PointerEventData eventData) {
		PlayerPrefs.SetString ("isDragging", "false");

		OnSwipeEnd.Invoke(eventData.position);

		if (eventData.position.x - startDragPosition.x > Screen.width / 2) {
			signUpToTheRight = true;
		} else {
			signUpToTheRight = false;
		}
		if (signUpToTheRight) {
			StartCoroutine (UpdatePathToRightSide ());
			if (signUp.name.Equals("Sign Up")) {
				PlayerPrefs.SetString ("BufferPhoto", PlayerPrefs.GetString ("PhotoSaved"));
			}
			CameraManager.Instance.StopCamera ();
		} else  {
			StartCoroutine (UpdatePathToLeftSide ());
		}
		if (photoImage != null) {
			UpLoadPhotoFromPlayerPrefs ();
		}
	}

	public void UpLoadPhotoFromPlayerPrefs()
	{
		if (PlayerPrefs.GetString ("PhotoSaved").Equals ("")) {
			photoImage.texture = avatarIcon.GetComponent<Image>().sprite.texture;
			Texture2D image = (Texture2D)photoImage.texture;
			Texture2D rotatedImage = rotateTexture(image, false); 
			photoImage.texture = rotatedImage;
		}
	}

	Texture2D rotateTexture(Texture2D originalTexture, bool clockwise) {
     
         Color32[] original = originalTexture.GetPixels32();
         Color32[] rotated = new Color32[original.Length];
         int w = originalTexture.width;
         int h = originalTexture.height;
 
         int iRotated, iOriginal;
 
         for (int j = 0; j < h; ++j)
         {
             for (int i = 0; i < w; ++i)
             {
                 iRotated = (i + 1) * h - j - 1;
                 iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                 rotated[iRotated] = original[iOriginal];
             }
         }
 
         Texture2D rotatedTexture = new Texture2D(h, w);
         rotatedTexture.SetPixels32(rotated);
         rotatedTexture.Apply();
         return rotatedTexture;
     }

	public void OnDrag(PointerEventData eventData) {
		direction = eventData.position - _lastPosition;
		if (signUp.transform.transform.position.x > Screen.width / 2 || direction.x > 0) {				
			signUp.transform.position += new Vector3 (direction.x, 0, 0);
		}
		_lastPosition = eventData.position;
		OnSwipe.Invoke(direction);
	}

	private IEnumerator UpdatePathToRightSide()
	{
		while (signUp.transform.position.x  < Screen.width + Screen.width / 2) {
			if (signUp.transform.position.x + speed < Screen.width + Screen.width / 2) {
				signUp.transform.position += new Vector3 (speed, 0, 0);
			} else {
				signUp.transform.position += new Vector3 (Screen.width + Screen.width / 2 - signUp.transform.position.x, 0, 0);

			}
			yield return null;
		}
	}

	private IEnumerator UpdatePathToLeftSide()
	{
		while (signUp.transform.position.x  > Screen.width / 2) {
			
			if (signUp.transform.position.x - speed >Screen.width / 2) {
				signUp.transform.position -= new Vector3 (speed, 0, 0);
			} else {
				signUp.transform.position -= new Vector3 (signUp.transform.position.x - Screen.width / 2, 0, 0);

			}

			yield return null;
		}
	}


}
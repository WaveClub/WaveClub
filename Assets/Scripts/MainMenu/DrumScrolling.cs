using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrumScrolling : MonoBehaviour {
	[Header("Prefabs")]
	public GameObject stretchingPrefab;
	public GameObject stretchingPrefab_80;
	public GameObject stretchingPrefab_60;
	public GameObject stretchingPrefab_40;
	[Header("Settings")]
	[Range(0f, 20f)]
	public float stretchingReturnSpeed;
	[Range(0f, 5f)]
	public float scale;
	public ScrollRect scrollRect;

	private GameObject[] objsStretching;
	private Vector2[] posStretching;
	private Vector2[] scaleStretching;
	private int stretchingCount = 500;
	private int offset = 4;

	private RectTransform contentRect;
	private Vector2 tempContentVector;
	private int currentStretchingId;
	private bool isScrolling;

	void Start () {
		contentRect = GetComponent<RectTransform> ();
		objsStretching = new GameObject[stretchingCount];
		posStretching = new Vector2[stretchingCount];
		scaleStretching = new Vector2[stretchingCount];

		for (int i = 0; i < stretchingCount; i++)
		{
			objsStretching[i] = Instantiate (stretchingPrefab, transform, false);

			if (i == 0) {
				objsStretching [i].transform.localPosition = new Vector2 (0, 385);
				posStretching [i] = -objsStretching [i].transform.localPosition;
				continue;
			}
			objsStretching [i].transform.localPosition = new Vector2 (objsStretching[i - 1].transform.localPosition.x,
				objsStretching[i - 1].transform.localPosition.y - stretchingPrefab.GetComponent<RectTransform>().sizeDelta.y - offset + 50);
			posStretching [i] = -objsStretching [i].transform.localPosition;
		}
	}

	void FixedUpdate () {
		float nearest = float.MaxValue;
		for (int i = 0; i < stretchingCount; i++) {
			float dist = Mathf.Abs(contentRect.anchoredPosition.y - posStretching [i].y);
			if (dist < nearest) {
				nearest = dist;
				currentStretchingId = i;
			}

			if (dist > 400) {
				objsStretching [i].SetActive (false);
			} else {
				objsStretching [i].SetActive (true);
			}

			float tempScale = Mathf.Clamp (1 / (dist / offset) * scale, 0.5f, 1f);
			scaleStretching [i].x = Mathf.SmoothStep (objsStretching [i].transform.localScale.x, tempScale, 10 * Time.fixedDeltaTime);
			scaleStretching [i].y = Mathf.SmoothStep (objsStretching [i].transform.localScale.y, tempScale, 10 * Time.fixedDeltaTime);
			objsStretching [i].transform.localScale = scaleStretching [i];
		}

		float scrollVelocity = Mathf.Abs(scrollRect.velocity.y);
		if (scrollVelocity < 400 && !isScrolling)
			scrollRect.inertia = false;
		
		if (isScrolling || scrollVelocity > 400)
			return;
		
		tempContentVector.y = Mathf.SmoothStep (contentRect.anchoredPosition.y, posStretching[currentStretchingId].y, stretchingReturnSpeed * Time.fixedDeltaTime);
		contentRect.anchoredPosition = tempContentVector;
	}

	public void Scrolling(bool isScroll) {
		isScrolling = isScroll;
		if (isScrolling) {
			scrollRect.inertia = true;
			Handheld.Vibrate ();
		}
	}
}

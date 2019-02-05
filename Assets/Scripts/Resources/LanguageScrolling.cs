using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScrolling : MonoBehaviour {
	[Header("Settings")]
	public List<string> languages;
	[Range(1f, 20f)]
	public float speed;
	[Range(1f, 5f)]
	public float mScale;
	[Header("Game Objects")]
	public GameObject languagePrefab;
	public ScrollRect languageScroll;

	private GameObject[] instLanguages;
	private Vector2[] instLanguagesPos;
	private Vector2[] instLanguagesScale;

	private RectTransform contentRect;
	private Vector2 contentVector;

	private int selectedLanguage;
	private bool isScrolling;

	void Start () {
		contentRect = GetComponent<RectTransform> ();

		instLanguages = new GameObject[languages.Count];
		instLanguagesPos = new Vector2[languages.Count];
		instLanguagesScale = new Vector2[languages.Count];
		for (int i = 0; i < languages.Count; i++) {
			instLanguages [i] = Instantiate (languagePrefab, transform, false);
			instLanguages [i].GetComponent<Text> ().text = languages [i];
			instLanguages [i].transform.localPosition = new Vector2 (i * languagePrefab.GetComponent<RectTransform>().sizeDelta.x, 0);
			instLanguagesPos [i] = -instLanguages [i].transform.localPosition;
		}
	}

	private void FixedUpdate () {
		if (!isScrolling && (contentRect.anchoredPosition.x >= instLanguagesPos [0].x || 
				contentRect.anchoredPosition.x <= instLanguagesPos [languages.Count - 1].x)
		) {
			languageScroll.inertia = false;
		}
		float nearestPos = float.MaxValue;
		for (int i = 0; i < languages.Count; i++) {
			float distance = Mathf.Abs (contentRect.anchoredPosition.x - instLanguagesPos [i].x);
			if (distance < nearestPos) {
				nearestPos = distance;
				selectedLanguage = i;
			}

			float scale = Mathf.Clamp (1 / distance * mScale, 0.5f, 1f);
			instLanguagesScale [i].x = Mathf.SmoothStep (instLanguages[i].transform.localScale.x, scale, 20 * Time.fixedDeltaTime);
			instLanguagesScale [i].y = Mathf.SmoothStep (instLanguages[i].transform.localScale.y, scale, 20 * Time.fixedDeltaTime);
			instLanguages [i].transform.localScale = instLanguagesScale [i];
		}

		if (languages [selectedLanguage] != LocalizationManager.Instance.LanguageCode)
			LocalizationManager.Instance.LanguageCode = languages [selectedLanguage];

		float scrollVelocity = Mathf.Abs (languageScroll.velocity.x);
		if (scrollVelocity < 400 && !isScrolling) {
			languageScroll.inertia = false;
		}
		if (isScrolling || scrollVelocity > 400)
			return;

		contentVector.x = Mathf.SmoothStep (contentRect.anchoredPosition.x, instLanguagesPos [selectedLanguage].x, speed * Time.fixedDeltaTime);
		contentRect.anchoredPosition = contentVector;
	}

	public void Scrolling(bool isScroll) {
		isScrolling = isScroll;
		if (isScroll)
			languageScroll.inertia = true;
	}
}

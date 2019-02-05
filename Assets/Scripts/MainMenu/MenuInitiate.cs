using UnityEngine;
using System.Collections;

public class MenuInitiate : MonoBehaviour
{
	[Header("Theme")]
	public GameObject Blue;
	public GameObject Pink;

	void Start ()
	{
		var user = JsonUtility.FromJson<UserIdentifier> (PlayerPrefs.GetString ("UserIdentifier"));

		// Set Theme
		Blue.SetActive (user.Sex);
		Pink.SetActive (!user.Sex);
	}

	void OnEnable () {
		var user = JsonUtility.FromJson<UserIdentifier> (PlayerPrefs.GetString ("UserIdentifier"));

		// Set Theme
		Blue.SetActive (user.Sex);
		Pink.SetActive (!user.Sex);
	}
}


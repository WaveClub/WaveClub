using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RequestHelper {
	[Header("UIMessage")]
	public static GameObject UIMessageObject;
	public static Text UIMessageText;

	[Header("UISpinner")]
	public static GameObject UISpinner;

	private const string url = "http://waveclubproject-001-site1.gtempurl.com/api";
//	private const string url = "http://localhost:21520/api";

	private static string curLanguage;
	private static Dictionary<string, string> config;

	public static IEnumerator PostRequest(string body, string method, System.Action<string> result) 
	{
		UISpinner.SetActive (true);

		var postHeaders = new Dictionary<string, string> ();
		postHeaders.Add ("Content-Type", "application/json");
//		postHeaders.Add ("Accept-Encoding", "gzip, deflate");
		if (PlayerPrefs.GetString ("AccessToken") != null) {
			postHeaders.Add ("Authorization", PlayerPrefs.GetString ("AccessToken"));
		}

		var data = System.Text.Encoding.UTF8.GetBytes (body.ToCharArray ());
		var response = new WWW (url + method, data, postHeaders);

		yield return response;

		ResponseProcessing (response, result);
		response.Dispose ();
	}

	public static IEnumerator GetRequest(string method, System.Action<string> result) {
		UISpinner.SetActive (true);

		var getHeaders = new Dictionary<string, string> ();
		getHeaders.Add ("Content-Type", "application/json");
		//		postHeaders.Add ("Accept-Encoding", "gzip, deflate");
		if (PlayerPrefs.GetString ("AccessToken") != null) {
			getHeaders.Add ("Authorization", PlayerPrefs.GetString ("AccessToken"));
		}

		var response = new WWW (url + method, null, getHeaders);

		yield return response;

		ResponseProcessing (response, result);
		response.Dispose ();
	}

	private static void ResponseProcessing(WWW response, System.Action<string> result) {
		UISpinner.SetActive (false);
		if (response.error != null) {
			
			if (curLanguage == null || curLanguage != LocalizationManager.Instance.LanguageCode) {
				curLanguage = LocalizationManager.Instance.LanguageCode;
				config = LocalizationManager.getConfig ("response_messages");
			}

			BaseResponse br = JsonUtility.FromJson<BaseResponse> (response.text);
			if (br != null && br.Message != string.Empty) {
				UIMessageText.text = config [br.Message.Split ('.') [1]];
				UIMessageObject.SetActive (true);
			}
		} else {
			string token;
			if (response.responseHeaders.TryGetValue("Authentication", out token))
				PlayerPrefs.SetString ("AccessToken", "JWT " + token);

			result (response.text);
		}
	}
}

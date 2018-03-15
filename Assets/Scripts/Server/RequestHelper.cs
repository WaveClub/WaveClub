using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestHelper {
	private const string url = "http://82.202.246.165/api/v1";

	public static IEnumerator PostRequest(string body, string method, System.Action<string> result)
	{
		var postHeaders = new Dictionary<string, string> ();
		postHeaders.Add ("Content-Type", "application/json");
		postHeaders.Add ("Accept-Encoding", "gzip, deflate");

		var data = System.Text.Encoding.ASCII.GetBytes(body.ToCharArray());

		var response = new WWW(url + method, data, postHeaders);
		yield return response;

//		Раскомментировать и добавить обработку!
//		if (response.error != null)
//			Debug.Log("Server does not respond : " + response.error);
//		else
			result (response.text);
		
		response.Dispose();
	}
}

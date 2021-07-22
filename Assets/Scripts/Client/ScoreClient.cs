using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using System;


public class ScoreClient {
	public static IEnumerator GetTopScores(int gameId, Action<Score[]> callback) {
		UnityWebRequest request = UnityWebRequest.Get($"{Api.address}/ranking/{gameId}");
		yield return request.SendWebRequest();
		string json = request.downloadHandler.text;
		Score[] scores = JsonHelper.FromJsonArray<Score>(json);
		callback(scores);
	}

	public static IEnumerator AddScore(NewScore newScore, Action<bool> callback) {
		string json = JsonUtility.ToJson(newScore);
		string url = $"{Api.address}/scores";
		UnityWebRequest request = new UnityWebRequest(url, "POST");
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
		request.uploadHandler = new UploadHandlerRaw(bytes);
		request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");
		yield return request.SendWebRequest();
		if (request.result == UnityWebRequest.Result.Success) {
			Debug.Log(request.downloadHandler.text);
			callback(true);
		} else {
			Debug.Log(request.error);
			callback(false);
		}
	}
}
using System;
using UnityEngine;

[Serializable]
public class Score {
	public int id;
	public int score;
	public User user;
	public Game game;
	[SerializeField] private string player_name;

	public string playerName { get => player_name; set => player_name = value; }
}

[Serializable]
public class NewScore {
	public int score;
	[SerializeField] private int game_id;
	[SerializeField] private string player_name;
	[SerializeField] private string registration_number;
	[SerializeField] private string institution_name;

	public string playerName { get => player_name; set => player_name = value; }
	public string registrationNumber { get => registration_number; set => registration_number = value; }
	public string institutionName { get => institution_name; set => institution_name = value; }
	public int gameId { get => game_id; set => game_id = value; }

	public NewScore(int gameId, int score, string registrationNumber, string institutionName, string playerName) {
		this.gameId = gameId;
		this.score = score;
		this.registrationNumber = registrationNumber;
		this.institutionName = institutionName;
		this.playerName = playerName;
	}
}
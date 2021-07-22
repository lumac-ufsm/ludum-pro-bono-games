using System;
using UnityEngine;

[Serializable]
public class User {
	public int id;
	public string name;
	[SerializeField] private string registration_number;
	public Institution institution;

	public string registrationNumber { get => registration_number; set => registration_number = value; }

	public User(int id, string name, Institution institution, string registrationNumber) {
		this.id = id;
		this.name = name;
		this.institution = institution;
		this.registrationNumber = registrationNumber;
	}

}
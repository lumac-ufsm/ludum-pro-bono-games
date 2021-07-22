using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectorManager : MonoBehaviour {
	[SerializeField] private GameName _gameName;
	public GameName gameName {
		get { return _gameName; }
	}
}

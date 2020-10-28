using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLevelButton : MonoBehaviour {
    private Level _level;
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    public Level level {
        get {
            return _level;
        }
        set {
            _level = value;
            text.text = level.number.ToString();
            button.interactable = level.unlocked;
            text.enabled = level.unlocked;
        }
    }

    private void Start() {
        button.onClick.AddListener(() => level.Start());
    }
}

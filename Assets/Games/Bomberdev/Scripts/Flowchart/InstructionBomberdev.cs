using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionBomberdev : MonoBehaviour {
    [SerializeField] private Image image;
    [SerializeField] private Text text;
    [SerializeField] private Color colorDefault;
    [SerializeField] private Color colorSelect;
    [SerializeField] private Color colorHold;
    [SerializeField] private CommandBomberdev _command;

    public CommandBomberdev command { get { return _command; } }

    private bool _hold;
    public bool hold {
        get { return _hold; }
        private set { _hold = value; }
    }
    
    public void Select() {
        image.color = colorSelect;
    }

    public void Unselect() {
        image.color = colorDefault;
    }

    public void Hold() {
        hold = true;
        image.color = colorHold;
    }

    public void Drop() {
        hold = false;
        Select();
    }

    public void ToggleHold() {
        if (hold) Drop();
        else Hold();
    }
}

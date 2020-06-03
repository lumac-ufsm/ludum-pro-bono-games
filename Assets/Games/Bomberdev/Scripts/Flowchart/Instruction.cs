using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {
    [SerializeField] private Image image;
    [SerializeField] private Text text;
    [SerializeField] private Color colorDefault;
    [SerializeField] private Color colorSelect;
    [SerializeField] private Color colorHold;
    
    public void Select() {
        image.color = colorSelect;
    }

    public void Unselect() {
        image.color = colorDefault;
    }

    public void Hold() {
        image.color = colorHold;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {
    [SerializeField] private Image image;
    [SerializeField] private Text text;
    [SerializeField] private Color colorSelect;
    
    private void Start() {
        Select();
    }
    
    public void Select() {
        image.color = colorSelect;
    }
}

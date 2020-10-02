using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Redirect : MonoBehaviour
{
    
    [SerializeField]
    public float tempo = 20;
    private float contadortempo = 0;
    private SelectGame selectGame;
    

    private void Start()
    {
        this.selectGame = MainCamera.FindObjectOfType<SelectGame>();
        string nome = selectGame.nomeJogo; 

    }



    // Update is called once per frame
    void Update()
    {
        contadortempo += Timeout.deltaTime;
        if (contadortempo == tempo)
        {
            SceneManager.LoadScene("Games/" + nome + "/Scenes/Main");   // seria interessante deixar essa rotina genérica, buscando a string nomejogo
        }

    }
} 

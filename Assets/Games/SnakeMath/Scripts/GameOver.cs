using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text textPontuacao;

    // Start is called before the first frame update
    void Start()
    {
        textPontuacao.text = "Pontuação: " + SnakeStorage.points;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Keys.start))
        {
            SceneManager.LoadScene("Scenes/SnakeCalculator/SnakeCalculator");
        }
    }
}

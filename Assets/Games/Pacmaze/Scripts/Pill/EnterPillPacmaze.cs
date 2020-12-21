using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPillPacmaze : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            string name = SceneManager.GetActiveScene().name;
            int level = int.Parse(name.Replace("_PacmazeLevel", ""));
            if(level == 7){
                //Mostrar tela de game over
            }else{
                SceneManager.LoadScene($"{level + 1}_PacmazeLevel");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerPerdiste : MonoBehaviour
{
    public TMP_Text ScoreText; // Referencia al componente TMP_Text donde se mostrar� la puntuaci�n
    
    void Start()
    {
        ScoreText.text = "Tu Puntuaci�n: " + ScoreManager._score; //Llama a la variable del score logrado en la partida
    }

    // M�todo para cargar la escena "SampleScene"
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
        ScoreManager._score = 0; //Se reinicia el valor del score
    }

    // M�todo para cargar la escena "Inicio"
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Inicio");
        ScoreManager._score = 0; //Se reinicia el valor del score
    }
}

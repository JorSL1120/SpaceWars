using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text ScoreText; // Referencia al texto de la puntuaci�n en el Canvas
    public static int _score = 0; // Puntuaci�n actual del jugador
    public Player player; // Referencia al script del jugador

    void Start()
    {
        UpdateScoreUI(); // Actualizar el texto de la puntuaci�n al inicio
    }

    // M�todo para sumar puntos
    public void AddScore(int points)
    {
        _score += points; // Sumar puntos a la puntuaci�n actual
        UpdateScoreUI(); // Actualizar el texto de la puntuaci�n

        player.CheckScoreForExtraLife(); // Verificar si el jugador ha ganado una vida
    }

    // M�todo para actualizar el texto de la puntuaci�n en el Canvas
    void UpdateScoreUI()
    {
        ScoreText.text = _score.ToString(); // Actualizar el texto con la puntuaci�n actual
    }

    // M�todo para obtener la puntuaci�n actual
    public int GetScore()
    {
        return _score;
    }
}

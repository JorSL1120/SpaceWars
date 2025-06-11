using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text ScoreText; // Referencia al texto de la puntuación en el Canvas
    public static int _score = 0; // Puntuación actual del jugador
    public Player player; // Referencia al script del jugador

    void Start()
    {
        UpdateScoreUI(); // Actualizar el texto de la puntuación al inicio
    }

    // Método para sumar puntos
    public void AddScore(int points)
    {
        _score += points; // Sumar puntos a la puntuación actual
        UpdateScoreUI(); // Actualizar el texto de la puntuación

        player.CheckScoreForExtraLife(); // Verificar si el jugador ha ganado una vida
    }

    // Método para actualizar el texto de la puntuación en el Canvas
    void UpdateScoreUI()
    {
        ScoreText.text = _score.ToString(); // Actualizar el texto con la puntuación actual
    }

    // Método para obtener la puntuación actual
    public int GetScore()
    {
        return _score;
    }
}

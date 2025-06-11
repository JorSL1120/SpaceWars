using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVidaV2 : MonoBehaviour
{
    public int MaxHealth; // Vidas máximas del enemigo
    private int _currentHealth; // Vidas actuales del enemigo

    ScoreManager scoreManager; // Variable para almacenar una referencia al ScoreManager

    void Start()
    {
        _currentHealth = MaxHealth; // Al inicio, el enemigo tiene el máximo de vidas
        scoreManager = FindObjectOfType<ScoreManager>(); // Encontrar el ScoreManager en la escena
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la colisión proviene de una bala
        if (other.gameObject.tag == "Bullet")
        {
            // Reducir la vida del enemigo
            TakeDamage();
            // Destruir la bala
            Destroy(other.gameObject);
        }
    }

    void TakeDamage()
    {
        _currentHealth--; // Reducir la vida del enemigo

        // Si la vida llega a cero, destruir el enemigo
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            scoreManager.AddScore(30); // Sumar 30 puntos
        }
    }
}

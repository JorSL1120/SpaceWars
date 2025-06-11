using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullets : MonoBehaviour
{
    public float Speed; // Velocidad de la bala
    public float DestroyAfter; // Tiempo después del cual se destruye la bala si no colisiona con nada
    ScoreManager scoreManager; // Variable para almacenar una referencia al ScoreManager

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Encontrar el ScoreManager en la escena
        // Destruye la bala después de un tiempo
        Destroy(gameObject, DestroyAfter);
    }

    void Update()
    {
        // Movimiento de la bala hacia arriba
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si la bala colisiona con un enemigo, destrúyela
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoreManager.AddScore(10); // Sumar 10 puntos
        }
        
        if(other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

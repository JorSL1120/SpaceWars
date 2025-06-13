using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float VelocidadMovimiento; //Velocidad en la que se desplaza el player
    public float LimiteIzquierdo; //Limite de la pantalla en la que se puede mover hacia la izquierda
    public float LimiteDerecho; //Limite de la pantalla en la que se puede mover hacia la derecha
    public GameObject BalaPrefab; //Se coloca el prefab de la bala del player
    public Transform PuntoDisparo; //Se coloca el Empty de donde saldra la bala del player
    public float CadenciaDisparo; //Cada cuanto puede salir una bala
    public int MaxHealth; // Vidas m�ximas del jugador
    public Image[] HealthSprites; // Im�genes de los sprites de vida en el Canvas
    public ScoreManager scoreManager; // Referencia al script de administraci�n de puntaje

    private int _currentHealth; // Vidas actuales del jugador
    private float _proximoDisparo; //Cuando sale el proximo disparo

    public AudioClip blasterShoot;

    void Start()
    {
        _currentHealth = MaxHealth; // Al inicio, el jugador tiene el m�ximo de vidas
        UpdateHealthUI(); //Se llama al metodo que actualiza la vida en el canvas
    }

    void Update()
    {
        MovPlayer(); //Se llama al metodo que hace que el player se mueva
        Shooting(); //Se llama al metodo que hace los disparos
    }

    void MovPlayer()
    {
        //Movimiento Horizontal
        float _movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _movimientoHorizontal * VelocidadMovimiento * Time.deltaTime);

        //Limitar el movimiento dentro de los limites
        Vector3 _posicionActual = transform.position;
        _posicionActual.x = Mathf.Clamp(_posicionActual.x, LimiteIzquierdo, LimiteDerecho);
        transform.position = _posicionActual;
    }

    void Shooting()
    {
        //Disparo
        if (Time.time > _proximoDisparo && Input.GetButton("Fire1"))
        {
            Disparar();
            _proximoDisparo = Time.time + CadenciaDisparo;
        }
    }

    //Crea la bala en el Empty
    void Disparar()
    {
        Instantiate(BalaPrefab, PuntoDisparo.position, Quaternion.identity);

        AudioSource.PlayClipAtPoint(blasterShoot, transform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la colisi�n proviene de una bala enemiga
        if (other.gameObject.tag == "EnemyBullet")
        {
            // Reducir la vida del jugador
            TakeDamage();
            // Destruir la bala enemiga
            Destroy(other.gameObject);
        }
    }

    //Controla el da�o que le hacen al player
    void TakeDamage()
    {
        _currentHealth -= 1; // Reducir la vida del jugador
        UpdateHealthUI(); // Actualizar la visualizaci�n de las vidas en el Canvas

        // Si la vida llega a cero, el jugador se destruye (o cualquier otra acci�n que desees realizar)
        if (_currentHealth <= 0)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene("Perdiste");
        }
    }

    // Actualizar la visualizaci�n de las vidas en el Canvas
    void UpdateHealthUI()
    {
        for (int i = 0; i < HealthSprites.Length; i++)
        {
            if (i < _currentHealth)
            {
                HealthSprites[i].enabled = true; // Mostrar el sprite de vida
            }
            else
            {
                HealthSprites[i].enabled = false; // Ocultar el sprite de vida
            }
        }
    }

    // M�todo para verificar si el jugador ha ganado una vida por puntaje
    public void CheckScoreForExtraLife()
    {
        int currentScore = scoreManager.GetScore();
        if (currentScore % 100 == 0 && currentScore >= 100 && _currentHealth < MaxHealth)
        {
            _currentHealth++; // A�adir una vida
            UpdateHealthUI(); // Actualizar la visualizaci�n de las vidas en el Canvas
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public GameObject BulletPrefab; // Prefab de la bala
    public Transform FirePoint; // Punto de origen del disparo
    public float ShootInterval; // Intervalo entre disparos
    public float MoveSpeed; // Velocidad de movimiento aleatorio
    public float ChangeDirectionInterval; // Intervalo entre cambios de dirección
    public float LimiteIzquierdo; // Límite izquierdo del rango de movimiento
    public float LimiteDerecho; // Límite derecho del rango de movimiento
    public float LimiteAbajo; // Límite inferior del rango de movimiento
    public float LimiteArriba; // Límite superior del rango de movimiento

    private float _nextShootTime;
    private float _nextDirectionChangeTime;
    private Vector2 _moveDirection;

    void Start()
    {
        _nextShootTime = Time.time + ShootInterval;
        _nextDirectionChangeTime = Time.time + ChangeDirectionInterval;

        // Iniciar con una dirección de movimiento aleatorio
        _moveDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Disparar hacia abajo
        if (Time.time >= _nextShootTime)
        {
            Shoot();
            _nextShootTime = Time.time + ShootInterval;
        }

        // Movimiento aleatorio
        if (Time.time >= _nextDirectionChangeTime)
        {
            ChangeDirection();
            _nextDirectionChangeTime = Time.time + ChangeDirectionInterval;
        }

        // Movimiento dentro de los límites del rango
        Vector3 newPos = transform.position + (Vector3)_moveDirection * MoveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, LimiteIzquierdo, LimiteDerecho);
        newPos.y = Mathf.Clamp(newPos.y, LimiteAbajo, LimiteArriba);
        transform.position = newPos;
    }

    void Shoot()
    {
        // Instanciar una nueva bala
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
        // Disparar hacia abajo
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * MoveSpeed;
    }

    void ChangeDirection()
    {
        // Cambiar la dirección de movimiento aleatorio
        _moveDirection = Random.insideUnitCircle.normalized;
    }
}

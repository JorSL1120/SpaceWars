using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    
    public float DestroyAfter; // Tiempo despu�s del cual se destruye la bala si no colisiona con nada

    void Start()
    {
        // Destruye la bala despu�s de un tiempo
        Destroy(gameObject, DestroyAfter);
    }
}

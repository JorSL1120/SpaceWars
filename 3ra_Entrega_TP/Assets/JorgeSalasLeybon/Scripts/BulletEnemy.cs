using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    
    public float DestroyAfter; // Tiempo después del cual se destruye la bala si no colisiona con nada

    void Start()
    {
        // Destruye la bala después de un tiempo
        Destroy(gameObject, DestroyAfter);
    }
}

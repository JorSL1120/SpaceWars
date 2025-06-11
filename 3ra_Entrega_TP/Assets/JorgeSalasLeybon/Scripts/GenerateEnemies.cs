using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform EnemyPoint;
    public float GenerationInterval; // Intervalo entre generación de enemigos

    private float _nextGenerationTime;
    void Start()
    {
        _nextGenerationTime = Time.time + GenerationInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Generar nuevos enemigos
        if (Time.time >= _nextGenerationTime)
        {
            GeneratorEnemies();
            _nextGenerationTime = Time.time + GenerationInterval;
        }
    }

    void GeneratorEnemies()
    {
        // Generar dos nuevos enemigos
        for (int i = 0; i < 2; i++)
        {
            // Aquí deberías instanciar tus enemigos
            GameObject newEnemy = Instantiate(EnemyPrefab, EnemyPoint.position, Quaternion.identity);
        }
    }
}

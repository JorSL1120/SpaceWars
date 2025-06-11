using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public TMP_Text CuentaAtrasText; // Referencia al componente TMP_Text que mostrará la cuenta regresiva
    public float CuentaAtrasDuracion; // Duración total de la cuenta regresiva en segundos

    private float _cuentaAtrasTiempo; // Tiempo restante de la cuenta regresiva

    void Start()
    {
        _cuentaAtrasTiempo = CuentaAtrasDuracion; // Inicializar el temporizador de cuenta regresiva
        UpdateCountdownText(); // Actualizar el texto de la cuenta regresiva al inicio
    }

    void Update()
    {
        _cuentaAtrasTiempo -= Time.deltaTime; // Reducir el tiempo restante del temporizador

        if (_cuentaAtrasTiempo <= 0)
        {
            // Desactivar el objeto de la cuenta regresiva o cualquier otra acción que desees realizar
            gameObject.SetActive(false);
        }
        else
        {
            UpdateCountdownText(); // Actualizar el texto de la cuenta regresiva cada fotograma
        }
    }

    void UpdateCountdownText()
    {
        // Actualizar el texto de la cuenta regresiva con el tiempo restante formateado como segundos enteros
        CuentaAtrasText.text = Mathf.Max(0, Mathf.CeilToInt(_cuentaAtrasTiempo)).ToString(); // Utilizamos Mathf.Max para asegurarnos de que no sea menor que 0
    }
}

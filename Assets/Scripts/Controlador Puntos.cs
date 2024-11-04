using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos instance;

    [SerializeField] private float CantidadPuntos;

    private void Awake()
    {
        if (ControladorPuntos.instance == null)
        {
            ControladorPuntos.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(float puntos)
    {
        CantidadPuntos += puntos;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Secret : MonoBehaviour
{

    [SerializeField] Tilemap caminosecreto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colision");
        if (collision.tag == "Player")
        {
            Color color = caminosecreto.color;
            color.a = 0.5f;
            caminosecreto.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("desColision");
        if (collision.tag == "Player")
        {
            Color color = caminosecreto.color;
            color.a = 1f;
            caminosecreto.color = color;
        }
    }
}

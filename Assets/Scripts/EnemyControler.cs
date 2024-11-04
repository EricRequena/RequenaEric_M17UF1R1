using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // VARIABLES
    public float speed; // Velocidad de movimiento del enemigo
    public float minX; // Coordenada x mínima
    public float maxX; // Coordenada x máxima
    private Vector3 direction; // Dirección de movimiento

    void Start()
    {
        // Inicializa la dirección a la izquierda
        direction = Vector3.left;
    }

    void Update()
    {
        // Calcula la nueva posición del enemigo
        float newPositionX = transform.position.x + direction.x * speed * Time.deltaTime;

        // Verifica si ha alcanzado los límites
        if (newPositionX <= minX || newPositionX >= maxX)
        {
            // Cambia la dirección si se alcanza el límite
            direction = -direction;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        // Mueve el enemigo a la nueva posición
        transform.position += direction * speed * Time.deltaTime;
    }
}

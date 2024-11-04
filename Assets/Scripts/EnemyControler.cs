using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // VARIABLES
    public float speed; // Velocidad de movimiento del enemigo
    public float minX; // Coordenada x m�nima
    public float maxX; // Coordenada x m�xima
    private Vector3 direction; // Direcci�n de movimiento

    void Start()
    {
        // Inicializa la direcci�n a la izquierda
        direction = Vector3.left;
    }

    void Update()
    {
        // Calcula la nueva posici�n del enemigo
        float newPositionX = transform.position.x + direction.x * speed * Time.deltaTime;

        // Verifica si ha alcanzado los l�mites
        if (newPositionX <= minX || newPositionX >= maxX)
        {
            // Cambia la direcci�n si se alcanza el l�mite
            direction = -direction;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        // Mueve el enemigo a la nueva posici�n
        transform.position += direction * speed * Time.deltaTime;
    }
}

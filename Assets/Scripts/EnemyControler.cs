using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // VARIABLES
    public float speed; 
    public float minX; // Coordenada x mínima
    public float maxX; // Coordenada x máxima
    public float pauseDuration = 1f; // Duración de la pausa en cada extremo
    private Vector3 direction; // Dirección de movimiento
    private bool isPaused = false; // Estado de pausa

    void Start()
    {
        // Inicializa la dirección a la izquierda
        direction = Vector3.left;
    }

    void Update()
    {

        if (!isPaused)
        {
 
            float newPositionX = transform.position.x + direction.x * speed * Time.deltaTime;

    
            if (newPositionX <= minX || newPositionX >= maxX)
            {
                // Cambia la dirección si se alcanza el límite
                direction = -direction;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

                // Inicia la pausa en el movimiento
                StartCoroutine(PauseMovement());
            }

            // Mueve el enemigo a la nueva posición
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private IEnumerator PauseMovement()
    {
        isPaused = true; // Activa la pausa
        yield return new WaitForSeconds(pauseDuration); // Espera la duración de la pausa
        isPaused = false; // Desactiva la pausa
    }
}

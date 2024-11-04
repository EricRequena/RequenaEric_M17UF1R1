using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // VARIABLES
    public float speed; 
    public float minX; // Coordenada x m�nima
    public float maxX; // Coordenada x m�xima
    public float pauseDuration = 1f; // Duraci�n de la pausa en cada extremo
    private Vector3 direction; // Direcci�n de movimiento
    private bool isPaused = false; // Estado de pausa

    void Start()
    {
        // Inicializa la direcci�n a la izquierda
        direction = Vector3.left;
    }

    void Update()
    {

        if (!isPaused)
        {
 
            float newPositionX = transform.position.x + direction.x * speed * Time.deltaTime;

    
            if (newPositionX <= minX || newPositionX >= maxX)
            {
                // Cambia la direcci�n si se alcanza el l�mite
                direction = -direction;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

                // Inicia la pausa en el movimiento
                StartCoroutine(PauseMovement());
            }

            // Mueve el enemigo a la nueva posici�n
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private IEnumerator PauseMovement()
    {
        isPaused = true; // Activa la pausa
        yield return new WaitForSeconds(pauseDuration); // Espera la duraci�n de la pausa
        isPaused = false; // Desactiva la pausa
    }
}

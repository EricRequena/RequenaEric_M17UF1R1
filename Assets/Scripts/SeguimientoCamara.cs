using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Vector2 minCamPos, maxCamPos; // L�mites de movimiento de la c�mara
    public Transform target;

    void Start()
    {
        // Busca el prefab del jugador si no est� asignado
        if (target == null)
        {
            target = GameObject.FindWithTag("Player")?.transform;
        }
    }

    void Update()
    {
        // Si no encuentra el prefab, intenta buscarlo de nuevo
        if (target == null)
        {
            target = GameObject.FindWithTag("Player")?.transform;
            if (target == null) return; // Detiene el seguimiento si no hay jugador
        }

        // Actualiza la posici�n de la c�mara seg�n los l�mites
        float posx = target.position.x;
        float posy = target.position.y;

        transform.position = new Vector3(
            Mathf.Clamp(posx, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posy, minCamPos.y, maxCamPos.y),
            transform.position.z);
    }
}

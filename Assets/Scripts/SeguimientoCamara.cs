using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Vector2 minCamPos, maxCamPos; // Límites de movimiento de la cámara
    public Transform target;

    void Start()
    {
        // Busca el prefab del jugador si no está asignado
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

        // Actualiza la posición de la cámara según los límites
        float posx = target.position.x;
        float posy = target.position.y;

        transform.position = new Vector3(
            Mathf.Clamp(posx, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posy, minCamPos.y, maxCamPos.y),
            transform.position.z);
    }
}

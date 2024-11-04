using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float _speed = -1f;
    public float destroyTime = 3f; // Tiempo en segundos antes de destruir el objeto

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(_speed, 0);

        // Destruir el objeto después de 'destroyTime' segundos
        Destroy(gameObject, destroyTime);
    }
}

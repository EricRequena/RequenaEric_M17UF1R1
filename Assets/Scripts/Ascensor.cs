using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public int masaNeed = 15; 
    public Vector2 direction = Vector2.down;
    public float speed = 1.0f;
    public Vector2 position1;
    public Vector2 position2;
    public Vector2 position3;

    private Rigidbody2D _ascensor;
    [SerializeField] private int masaActual = 0; 


    [SerializeField] private bool movingToPosition2 = false;
    [SerializeField] private bool movingToPosition3 = false;


    void Start()
    {
        _ascensor = GetComponent<Rigidbody2D>();
        _ascensor.gravityScale = 0; // Desactiva la gravedad
    }

    void Update()
    {

        Debug.Log(masaActual);

        if (masaActual > 1 && masaActual < masaNeed && !movingToPosition3)
        {

            movingToPosition2 = true;
            _ascensor.velocity = direction * speed;
        }

        else if (masaActual >= masaNeed)
        {
            Debug.Log("Masa necesaria alcanzada");
            movingToPosition3 = true;
            Debug.Log("La posicion 3 es" + movingToPosition3);
            movingToPosition2 = false;  
            Debug.Log("La posicion 2 es" + movingToPosition2);
            _ascensor.velocity = direction * speed;
        }

       
        if (movingToPosition2 && Vector2.Distance(_ascensor.position, position2) < 0.2f)
        {
            _ascensor.position = position2; 
            _ascensor.velocity = Vector2.zero;
            movingToPosition2 = false;
        }
        else if (movingToPosition3 && Vector2.Distance(_ascensor.position, position3) < 0.2f)
        {
            _ascensor.position = position3; 
            _ascensor.velocity = Vector2.zero;


        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            masaActual = collision.gameObject.GetComponent<Box>().massa;
            Debug.Log("Caja añadida, masa total actual: " + masaActual);
  
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            masaActual = collision.gameObject.GetComponent<Box>().massa;
            Debug.Log("Caja removida, masa total actual: " + masaActual);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Runtime.CompilerServices;

public class PlayerControler : MonoBehaviour
{
    // VARIABLES
    public Animator aPlayer;
    public float velocidad; // VELOCIDAD DEL PERSONAJE
    public float velocidadMax; // VELOCIDAD MAXIMA DEL PERSONAJE
    public int points; // PUNTOS DEL JUGADOR
    public Rigidbody2D rPlayer; // RIGIDBODY DEL PERSONAJE
    public static PlayerControler instance; // SINGLETON
    public bool colPies = false; // COLISION CON LOS PIES

    public float h; // EJE HORIZONTAL
    public bool facingRight = true; // DIRECCION DEL PERSONAJE
    public bool isGrounded = false; // SI ESTA EN EL SUELO

    public Tilemap tilemap; // Tilemap para cambiar la opacidad de los tiles

    // SCENAS
    public int currentScene;
    public int sceneIndex;

    // START
    void Start()
    {
        rPlayer = GetComponent<Rigidbody2D>(); // OBTIENE EL COMPONENTE RIGIDBODY2D
        aPlayer = GetComponent<Animator>(); // OBTIENE EL COMPONENTE ANIMATOR
        sceneIndex = 0; // INICIALIZA EL INDICE DE ESCENA
        if (currentScene == 0)
        {
            SetPlayerPosition();
        }
    }

    // UPDATE
    void Update()
    {
        colPies = CheckGround.colPies; // OBTIENE LA COLISION CON LOS PIES
        // MOVIMIENTO
        Flip(h);
        aPlayer.SetFloat("VelocidadX", Mathf.Abs(rPlayer.velocity.x));

        // CAMBIO DE GRAVEDAD
        if (Input.GetKeyDown(KeyCode.Space) && colPies)
        {
            FlipGravity();
        }

        // CAMBIO DE ESCENA
        SceneControler();
    }

    // PACK MOVIMIENTO
    private void FixedUpdate() // MOVIMIENTO FIXEDUPDATE
    {
        h = Input.GetAxis("Horizontal"); // OBTIENE EL EJE HORIZONTAL
        rPlayer.AddForce(Vector2.right * velocidad * h); // AGREGA FUERZA AL RIGIDBODY
    }

    public void Flip(float horizontal) // VUELTA DEL PERSONAJE
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) // SI EL PERSONAJE ESTA EN UNA DIRECCION DIFERENTE
        {
            facingRight = !facingRight; // CAMBIA DE DIRECCION
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void FlipGravity() // VUELTA DE GRAVEDAD
    {
        rPlayer.gravityScale *= -1; // CAMBIA LA GRAVEDAD
        transform.Rotate(0f, 180f, 180f); // ROTA EL OBJETO
    }

    // PACK COLISIONES
    private void OnCollisionEnter2D(Collision2D collision) // COLISION TRUE
    {
        if (collision.gameObject.CompareTag("Suelo")) // SI COLISIONA CON EL SUELO
        {
            isGrounded = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {

            points++;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            SetPlayerPosition();
        }
    }



    private void OnCollisionExit2D(Collision2D collision) // COLISION FALSE
    {
        if (collision.gameObject.CompareTag("Suelo")) // SI NO COLISIONA CON EL SUELO
        {
            isGrounded = false;
        }
    }

    // SINGELTON
    void Awake() // NO DESTRUYE EL OBJETO AL CAMBIAR DE ESCENA
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // NO DESTRUYE EL OBJETO
        }
        else
        {
            Destroy(gameObject); // DESTRUYE EL OBJETO
        }
    }

    // CAMBIO DE ESCENA
    public void SceneControler() // CAMBIO DE ESCENA
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // OBTIENE NUMERO DE LA ESCENA
        if ((currentScene != sceneIndex) && currentScene > sceneIndex && (sceneIndex != 0 || sceneIndex != 5 || sceneIndex != 6)) // SI LA ESCENA ACTUAL ES DIFERENTE A LA ESCENA ANTERIOR
        {
            SetPlayerPosition();
        }
        sceneIndex = currentScene; // SE ACTUALIZA EL INDICE DE ESCENA
    }

    public void SetPlayerPositionLast()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex; // OBTIENE NUMERO DE LA ESCENA

        switch (sceneIndex)
        {
            case 1:
                transform.position = new Vector3(6, 13, 0);  // POSICION NIVEL 1
                break;
            case 2:
                transform.position = new Vector3(-5, 11, 0);  // POSICION NIVEL 2
                break;
            case 3:
                transform.position = new Vector3(7, 0, 0);  // POSICION NIVEL 3
                break;
            case 4:
                transform.position = new Vector3(-7, 0, 0);  // POSICION NIVEL 4
                break;
            case 0:
                transform.position = new Vector3(-50, 0, 0); // POSICION MENU
                break;
            case 5:
                transform.position = new Vector3(-50, 0, 0); // POSICION MENU
                break;
            case 6:
                transform.position = new Vector3(-50, 0, 0); // POSICION MENU
                break;


            default: // ERROR
                Debug.LogWarning("ID de escena desconocido, utilizando posición por defecto");
                transform.position = Vector3.zero;
                break;

        }
    }


        public void SetPlayerPosition() // CAMBIO DE POSICIÓN DEL JUGADOR
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex; // OBTIENE NUMERO DE LA ESCENA

            switch (sceneIndex)
            {
                case 1:
                    transform.position = new Vector3(-6, 0, 0);  // POSICION NIVEL 1
                    break;
                case 2:
                    transform.position = new Vector3(-5, 0, 0);  // POSICION NIVEL 2
                    break;
                case 3:
                    transform.position = new Vector3(-3, 0, 0);  // POSICION NIVEL 3
                    break;
                case 4:
                    transform.position = new Vector3(-7, 0, 0);  // POSICION NIVEL 4
                    break;
                case 0:
                    transform.position = new Vector3(-50, 0, 0); // POSICION MENU
                    break;
                case 5:
                    transform.position = new Vector3(-50, 0, 0); // POSICION MENU
                    break;
                case 6:
                    transform.position = new Vector3(-50, 0, 0); // POSICION MENU
                    break;


                default: // ERROR
                    Debug.LogWarning("ID de escena desconocido, utilizando posición por defecto");
                    transform.position = Vector3.zero;
                    break;
            }
        }

        // PACK MUERTE DE JUGADOR
        void OnBecameInvisible() // SE EJECUTA CUANDO EL OBJETO SALE DE LA PANTALLA
        {
            AudioManager.instance.PlaySoundDuko(); // REPRODUCE EL SONIDO DE MUERTE
            SetPlayerPosition(); // VUELVE A LA POSICIÓN INICIAL
        }


    }


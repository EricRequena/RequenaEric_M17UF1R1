using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartIndex : MonoBehaviour
{
    public int sceneIndex; // �ndice de la escena actual
    public GameObject gameObject; // Objeto

    // START
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; // Obtiene el �ndice de la escena actual
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int puntosJugador = PlayerControler.instance.points;

        // Disminuye el �ndice de la escena
        sceneIndex--;

        // Suscr�bete al evento de carga de escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Carga la nueva escena
        SceneManager.LoadScene(sceneIndex);
    }

    // Este m�todo se ejecutar� despu�s de que la escena se haya cargado
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Llama a la funci�n despu�s de cargar la escena
        PlayerControler.instance.SetPlayerPositionLast();

        // Desuscribirse del evento para evitar m�ltiples llamadas
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

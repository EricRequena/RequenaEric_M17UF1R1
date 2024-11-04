using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartIndex : MonoBehaviour
{
    public int sceneIndex; // Índice de la escena actual
    public GameObject gameObject; // Objeto

    // START
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; // Obtiene el índice de la escena actual
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int puntosJugador = PlayerControler.instance.points;

        // Disminuye el índice de la escena
        sceneIndex--;

        // Suscríbete al evento de carga de escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Carga la nueva escena
        SceneManager.LoadScene(sceneIndex);
    }

    // Este método se ejecutará después de que la escena se haya cargado
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Llama a la función después de cargar la escena
        PlayerControler.instance.SetPlayerPositionLast();

        // Desuscribirse del evento para evitar múltiples llamadas
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

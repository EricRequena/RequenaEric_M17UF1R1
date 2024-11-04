using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneByIndex()
    {
        // Suscríbete al evento de carga de escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Carga la nueva escena de manera asíncrona
        SceneManager.LoadSceneAsync(1);
    }

    // Método que se ejecuta cuando la nueva escena se ha cargado
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Llama a la función para establecer la posición del jugador
        PlayerControler.instance.SetPlayerPosition();

        // Desuscribirse del evento para evitar que se ejecute múltiples veces
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void salir()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

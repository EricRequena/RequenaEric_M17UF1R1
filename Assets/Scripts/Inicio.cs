using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneByIndex()
    {
        // Suscr�bete al evento de carga de escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Carga la nueva escena de manera as�ncrona
        SceneManager.LoadSceneAsync(1);
    }

    // M�todo que se ejecuta cuando la nueva escena se ha cargado
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Llama a la funci�n para establecer la posici�n del jugador
        PlayerControler.instance.SetPlayerPosition();

        // Desuscribirse del evento para evitar que se ejecute m�ltiples veces
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

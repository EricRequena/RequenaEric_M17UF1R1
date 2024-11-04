using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToSceneIndex1 : MonoBehaviour
{
    public int sceneIndex; //INIDICE DE LA ESCENA ACTUAL
    public AudioSource audioSource; //AUDIO DEL JUEGO
    public GameObject gameObject; //OBJETO

    //START
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; //OBTIENE EL INDICE DE LA ESCENA ACTUAL
    }



    //COLISION CON EL OBJETO
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        int puntosJugador = PlayerControler.instance.points;

        
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            AudioManager.instance.PlaySoundLevel();

        
    }
}

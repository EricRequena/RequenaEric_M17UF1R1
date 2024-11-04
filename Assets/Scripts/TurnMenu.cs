using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnMenu : MonoBehaviour
{
    public static TurnMenu instance;  
    public int remember;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            remember = SceneManager.GetActiveScene().buildIndex;
            AccionCuandoSePresionaP();
        }
    }

    public void AccionCuandoSePresionaP()
    {
        SceneManager.LoadSceneAsync(6);

    }
}

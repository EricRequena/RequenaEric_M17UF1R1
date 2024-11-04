using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreecnShake : MonoBehaviour
{

    [SerializeField] private float cantidadRotacion;
    [SerializeField] private float cantidadFuerza;

    private float tiempoRestante, fuerzaShake, tiempo, rotacion; 
    public static SreecnShake instance;


    private Vector3 posIni;

    private bool shake;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        shake = false;
    }

    private void LateUpdate()
    {
        if (shake)
        {
            if (tiempoRestante > 0f)
            {
                tiempoRestante -= Time.deltaTime;
                float cantidadX = posIni.x + Random.Range(-cantidadFuerza, cantidadFuerza) + fuerzaShake;
                float cantidadY = posIni.y + Random.Range(-cantidadFuerza, cantidadFuerza) + fuerzaShake;
                cantidadX = Mathf.MoveTowards(cantidadX, posIni.x, tiempo * Time.deltaTime);
                cantidadY = Mathf.MoveTowards(cantidadY, posIni.y, tiempo * Time.deltaTime);
                transform.position = new Vector3(cantidadX, cantidadY, posIni.z);
                rotacion = Mathf.MoveTowards(rotacion, 0f, tiempo * cantidadRotacion * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0F, 0F, rotacion * Random.Range(-1F, 1F));
            }
            else
            {
                transform.position = posIni;
                shake = false;
                
               
            }
        }
    }

    public void StartShake(float duration, float fuerza)
    {
        posIni = transform.position;
        shake = true;
        tiempoRestante = duration;
        fuerzaShake = fuerza;
        tiempo = fuerza/duration;
        rotacion = fuerza * cantidadRotacion;

    }

    // Update is called once per frame

}

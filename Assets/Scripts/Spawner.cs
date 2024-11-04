using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float time = 3f;
    public GameObject Arrow;
    public GameObject SpawnPoint;

    void Start()
    {
        StartCoroutine(SpawnArrow());
    }


    private IEnumerator SpawnArrow()
    {
        Instantiate(Arrow, SpawnPoint.transform.position, Quaternion.identity);
        AudioManager.instance.PlaySoundBall();
        yield return new WaitForSeconds(time);
        yield return SpawnArrow();
    }
}

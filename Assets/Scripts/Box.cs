using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int massa;

    void Start()
    {
        massa = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            massa += 5;
            Debug.Log("Masa actual" + massa);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            massa -= 5;
            Debug.Log("Masa actual" + massa);
        }
    }
}

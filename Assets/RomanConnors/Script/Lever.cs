using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject Door;
    public GameObject Calico;



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Door.SetActive(false);
            Calico.SetActive(true);


        }
    }
}

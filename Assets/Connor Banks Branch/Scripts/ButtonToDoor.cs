using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject[] platformPrefabs;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(door != null)
                Destroy(door);

            if (platformPrefabs != null)
                foreach (GameObject g in platformPrefabs)
                    g.SetActive(true);
                    

        }
    }
}

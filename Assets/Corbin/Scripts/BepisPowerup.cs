using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BepisPowerup : MonoBehaviour
{
    public static bool hasCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            hasCollected = true;
            Destroy(gameObject);
        }
    }
}

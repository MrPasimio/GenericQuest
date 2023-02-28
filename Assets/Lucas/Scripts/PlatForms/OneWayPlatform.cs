using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    //Variables
    public bool movingThroughPlatform = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //If player is below platform move to top
            if(collision.transform.position.y < transform.position.y)
            {
                collision.transform.position = new Vector3(collision.transform.position.x, transform.position.y + 1, collision.transform.position.z);
            }
        }
    }

}

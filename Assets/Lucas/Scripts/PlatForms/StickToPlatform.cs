using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //sets the parent of the player to this object.
            collision.gameObject.transform.parent = transform;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            //sets the parent of the player to this object.
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}

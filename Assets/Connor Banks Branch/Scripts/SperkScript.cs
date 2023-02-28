using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SperkScript : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerMovementButWithBEPIS>().Hurt();
        }
    }
}

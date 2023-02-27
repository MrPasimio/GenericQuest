using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Variables

    public Vector2 bounceDirection;
    public float bouncePower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceDirection * bouncePower, ForceMode2D.Impulse);
    }
}

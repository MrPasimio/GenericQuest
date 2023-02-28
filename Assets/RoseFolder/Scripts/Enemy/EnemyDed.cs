using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDed : MonoBehaviour
{
    public bool isHitOnHead;
    public GameObject player;
    public float bounceForce;
    public ParticleSystem deathParticles;


    private void Start()
    {
        deathParticles = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            if (isHitOnHead)
            {
               // yield return

                 StartCoroutine("Die");

            }
            else
            {
                player.GetComponent<PlayerMovement>().Hurt();
            }
        }
    }

    IEnumerator Die()
    {
        deathParticles.Play();
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
   
}

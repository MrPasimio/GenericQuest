using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetector1 : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyDeath ed = transform.parent.GetComponent<EnemyDeath>();

            ed.isHitOnHead = true;
            ed.player = collision.gameObject;
            ed.Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectionButDifferent : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EnemyDeathButDifferent ed = transform.parent.GetComponent<EnemyDeathButDifferent>();

            ed.isHitOnHead = true;
            ed.player = collision.gameObject;
            ed.Die();
        }
    }
}

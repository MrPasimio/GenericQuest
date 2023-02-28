using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHedDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyDed ed = transform.parent.GetComponent<EnemyDed>();

            ed.isHitOnHead = true;
            ed.player = collision.gameObject;
            ed.Die();
        }
    }
     
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

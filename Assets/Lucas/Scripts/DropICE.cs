using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropICE : MonoBehaviour
{
    //RigidBody
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Fall();
        }
    }


    public void Fall()
    {
        RB.gravityScale = 1;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

}

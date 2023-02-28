using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFunctionality : MonoBehaviour
{
    public Rigidbody2D PlayerRb;
    public float lowBounce;
    public float highBounce;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRb.AddForce(Vector2.up * lowBounce , ForceMode2D.Impulse);
            
            if (Input.GetKey(KeyCode.Space))
            {
                PlayerRb.AddForce(Vector2.up * highBounce, ForceMode2D.Impulse);
            }
        }
    }
}

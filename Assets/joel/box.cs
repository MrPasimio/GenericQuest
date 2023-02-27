using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed;
    public Vector2 target;
    private Vector2 position;
    public bool canpickup;
    public bool pickedUp;
    public GameObject weg;
    public GameObject box;
    
    // Start is called before the first frame update
    void Start()
    {
        target = weg.transform.position;
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup == true && Input.GetKey(KeyCode.E))
        {
            box.transform.SetParent(weg.transform);
            pickedUp = true;
            Debug.Log("picked up");
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(weg.transform.position, target, step);
            
        }
        
        if (pickedUp == true && Input.GetKeyUp(KeyCode.E))
        {
            pickedUp = false;
            Debug.Log("Thrown");
            
        }
           
        if (pickedUp == false)
        {
            box.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canpickup = true;
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canpickup = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolButBetter : MonoBehaviour
{
    public Transform groundDetector;
    public Transform wallDetector;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundDetector.position, Vector2.down, .5f);
        RaycastHit2D wall = Physics2D.Raycast(wallDetector.position, Vector2.right, .5f);

        if(ground.collider == null)
        {
            transform.Rotate(0, 180, 0);
        }

        if(wall.collider != null)
        {
            if (wall.collider.gameObject.CompareTag("Ground") || wall.collider.gameObject.CompareTag("Button") || wall.collider.gameObject.CompareTag("Sperk"))
            {
                transform.Rotate(Vector2.up, 180);
            }
        }
    }
}

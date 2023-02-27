using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float xPos;
    private float yPos;

    //Starting position variable
    private Vector2 startPos;

    //vertical movement
    public bool isMovingVertically;
    public float yAmplitude;
    public float yPeriod;
    public bool isYUsingCosine;
    //horizontal movement
    public bool isMovingHorizontally;
    public float xAmplitude;
    public float xPeriod;
    public bool isXUsingCosine;

    // Start is called before the first frame update
    void Start()
    {
        //save the start position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //vertical movement
        if (isMovingVertically)
        {
            if (isXUsingCosine)
            {
                float b = 6.28f / yPeriod;
                yPos = startPos.y + yAmplitude * Mathf.Cos(b * Time.time);
            }
            else
            {
                float b = 6.28f / yPeriod;
                yPos = startPos.y + yAmplitude * Mathf.Sin(b * Time.time);
            }
        }
        else
        {
            yPos = startPos.y;
        }

        //horizontal movement
        if (isMovingHorizontally)
        {
            if (isYUsingCosine)
            {
                float b = 6.28f / xPeriod;
                xPos = startPos.x + xAmplitude * Mathf.Cos(b * Time.time);
            }
            else
            {
                float b = 6.28f / xPeriod;
                xPos = startPos.x + xAmplitude * Mathf.Sin(b * Time.time);
            }

        }
        else
        {
            xPos = startPos.x;
        }

        //update the position
        transform.position = new Vector2(xPos, yPos);
    }

    //player and enemies can actually stick to the platforms
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}

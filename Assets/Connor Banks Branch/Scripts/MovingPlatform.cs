using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 startPos;

    //Position Variables
    public float xPos;
    public float yPos;

    //Horizontal Movement
    public bool isMovingHorizontally;
    public bool isXUsingCosine;
    public float xAmplitude;
    public float xPeriod;

    //Vertical Movement
    public bool isMovingVertically;
    public bool isYUsingCosine;
    public float yAmplitude;
    public float yPeriod;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement
        if(isMovingHorizontally)
        {
            float b = 2 * Mathf.PI / xPeriod;

            if(isXUsingCosine)
                xPos = startPos.x + xAmplitude * Mathf.Cos(b * Time.time);
            else
                xPos = startPos.x + xAmplitude * Mathf.Sin(b * Time.time);
        }
        else
        {
            xPos = transform.position.x;
        }

        //Vertical Movement
        if (isMovingVertically)
        {
            float b = 2 * Mathf.PI / yPeriod;

            if(isYUsingCosine)
                yPos = startPos.y + yAmplitude * Mathf.Cos(b * Time.time);
            else
                yPos = startPos.y + yAmplitude * Mathf.Sin(b * Time.time);
        }
        else
        {
            yPos = transform.position.y;
        }

        //Update position
        transform.position = new Vector2(xPos, yPos);
    }
}

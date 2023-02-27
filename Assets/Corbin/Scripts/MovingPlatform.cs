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
    [Header("Horizontal")]
    public bool isXUsingCosine;
    public bool horizontal;
    public float xAmp;
    public float xPer;



    //Vertical Movement
    [Header("Vertical")]
    public bool isYUsingCosine;
    public bool vertical;
    public float yAmp;
    public float yPer;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
        {
            float b = 6.28f / xPer;
            if (isXUsingCosine)
            {
                xPos = startPos.x + xAmp * Mathf.Cos(Time.time * b);
            }
            else
            {
                xPos = startPos.x + xAmp * Mathf.Sin(Time.time * b);
            }
        }
        else
        {
            xPos = transform.position.x;
        }


        if (vertical)
        {
            float b = 6.28f / yPer;
            if (isYUsingCosine)
            {
                yPos = startPos.y + yAmp * Mathf.Cos(Time.time * b);
            }
            else
            {
                yPos = startPos.y + yAmp * Mathf.Sin(Time.time * b);
            }
        }
        else
        {
            yPos = transform.position.y;
        }

        transform.position = new Vector2(xPos, yPos);
    }
}


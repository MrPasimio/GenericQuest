using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //current pos variables
    private float xPos;
    private float yPos;

    //starting pos variables
    private Vector2 startPos;


    //Vertical movement
    public bool isMovingVert; //Vertical
    public bool isYusingCosin;
    public float yAmp;
    public float yPer;

    //Horizontal
    public bool isMovingHoriz; //horizontal
    public bool isXusingCosin;
    public float xAmp;                                //Amplatude  distance in one direction from the middle
    public float xPer;                                //  Speed moving


    // Start is called before the first frame update
    void Start()
    {
        //Save start position
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        if (isMovingHoriz)
        {
            if (isXusingCosin)
            {
                float b = Mathf.PI / xPer;
                xPos = startPos.x + xAmp * Mathf.Cos(b * Time.time);
            }
            else
            {
                float b = Mathf.PI / xPer;
                xPos = startPos.x + xAmp * Mathf.Sin(b * Time.time);
            }
        }
        else
        {
            xPos = startPos.x;
        }

        //Vertical movement
        if (isMovingVert)
        {
            if (isYusingCosin)
            {
                float b = Mathf.PI / yPer;
                yPos = startPos.y + yAmp * Mathf.Cos(b * Time.time);
            }
            else
            {
                 float b = Mathf.PI / yPer;
                 yPos = startPos.y + yAmp * Mathf.Sin(b * Time.time);
            }
        }
        else
        {
            yPos = startPos.y;
        }

        //Update position
        transform.position = new Vector2(xPos, yPos);
    }
}

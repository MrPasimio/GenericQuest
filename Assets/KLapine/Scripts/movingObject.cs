using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{

    //current pos
    private float xPos;
    private float yPos;
    //start pos
    private Vector2 startPos;
    
    public bool IsMovingVertically;   //vertical movement
    public float yAmp;
    public bool isyUsingCosine;

    public bool IsMovingHorizontally;
    public float xAmp;
    public bool isxUsingCosine;

    public float yPer;
    public float xPer;
    // Start is called before the first frame update
    void Start()
    {
        //save start pos
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsMovingHorizontally)  
        {
            if (isxUsingCosine)
            {
                float b = 6.28f / xPer;
                xPos = startPos.x + xAmp * Mathf.Cos(b * Time.time);
            }
            else
            {
                float b = 6.28f / xPer;
                xPos = startPos.x + xAmp * Mathf.Sin(b * Time.time);
            }
        }
        else
        {
            xPos = startPos.x ;
        }

        if (IsMovingVertically)
        {
            if (isyUsingCosine)
            {
                float b = 6.28f / yPer;
                yPos = startPos.y + xAmp * Mathf.Cos(b * Time.time);
            }
            else
            {
                float b = 6.28f / yPer;
                yPos = startPos.y + xAmp * Mathf.Sin(b * Time.time);
            }
            
        }
        else
        {
            yPos = startPos.y;
        }
        //update pos
        transform.position = new Vector2(xPos, yPos);
    }
}

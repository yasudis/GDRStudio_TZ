using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public LineRenderer line;
    float moveSpeed = 10;
    Vector3[] moveToPoits;
    private int numberOfPoint=1;
    private int numberOfMovetoPoint = 1;
    private int countsOfPoint=100;
    

    void Start()
    {
       moveToPoits = new Vector3[countsOfPoint];
       line.positionCount = 1;
       line.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = 0;
            if (numberOfPoint < countsOfPoint)
            {
                moveToPoits[numberOfPoint] = pos;
                line.positionCount++;
                // line.SetPosition(100-numberOfPoint-1, pos);
                line.SetPosition(numberOfPoint, moveToPoits[numberOfPoint]);
               
                numberOfPoint += 1;


            }
            else
            {
                numberOfPoint = 0;
               // line.positionCount = 0;
            }

            //pos = (pos.x, pos.y, 0);
            //dir = (m_pos - (Vector2)transform.position).normalized;
        }
        if (moveToPoits[numberOfMovetoPoint]!=Vector3.zero) 
        {
        transform.position = Vector3.MoveTowards(transform.position, moveToPoits[numberOfMovetoPoint], moveSpeed * Time.deltaTime);
        if (transform.position== moveToPoits[numberOfMovetoPoint])
            {
                for (int i = 0; i < numberOfMovetoPoint; i++)
                {
                    line.SetPosition(i, transform.position);
                }
               

                Array.Clear(moveToPoits, numberOfMovetoPoint, 1);
                // line. = 0;
                
             //   Destroy(line.);
               //line.SetPosition(numberOfMovetoPoint, moveToPoits[numberOfMovetoPoint]);
                numberOfMovetoPoint += 1;

            }
        if (numberOfMovetoPoint>= countsOfPoint)
        {
            numberOfMovetoPoint = 0;
            
        }
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    //Vector3 pos;
    float moveSpeed = 10;
    Vector3[] moveToPoits;
    private int numberOfPoint=0;
    private int numberOfMovetoPoint = 0;
    private int countsOfPoint=100;

    void Start()
    {
        moveToPoits = new Vector3[countsOfPoint];  
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
                numberOfPoint += 1;
            }
            else
            {
                numberOfPoint = 0;
            }

            //pos = (pos.x, pos.y, 0);
            //dir = (m_pos - (Vector2)transform.position).normalized;
        }
        if (moveToPoits[numberOfMovetoPoint]!=Vector3.zero) 
        {
        transform.position = Vector3.MoveTowards(transform.position, moveToPoits[numberOfMovetoPoint], moveSpeed * Time.deltaTime);
        if (transform.position== moveToPoits[numberOfMovetoPoint])
            {
                Array.Clear(moveToPoits, numberOfMovetoPoint, 1);
               // moveToPoits[numberOfMovetoPoint]=0;
                numberOfMovetoPoint += 1;

            }
        if (numberOfMovetoPoint>= countsOfPoint)
        {
            numberOfMovetoPoint = 0;
        }
        }
    }
    private void MoveToPoits(Vector3 pos)
    {

    }
}

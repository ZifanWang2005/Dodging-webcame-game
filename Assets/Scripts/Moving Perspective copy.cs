using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPerspective : MonoBehaviour
{
    public UDPReceive udpReceive;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    float xVel = 0;
    float yVel = 0;
    float zVel = 0;
    float acceleration = 50;

    // Update is called once per frame

    void Update()
    {

        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        string[] points = data.Split(',');

        float x = float.Parse(points[0]);
        float y = float.Parse(points[1]);
        float z = float.Parse(points[2]);

        if (Math.Abs(x-xVel) < acceleration*Time.deltaTime)
        {
            x = xVel;
        }
        else if (x < xVel)
        {
            xVel -= acceleration*Time.deltaTime;
        }
        else if (x > xVel)
        {
            xVel += acceleration*Time.deltaTime;
        }
        else
        {
            xVel = 0;
        }

        transform.position = new Vector3(transform.position.x + xVel*Time.deltaTime, 
        transform.position.y, transform.position.z);

        // transform.Translate(new Vector3(x,y,z)*Time.deltaTime);
    }  
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movingv3 : MonoBehaviour
{
    public UDPReceive udpReceive;
    // Start is called before the first frame update


    public float acceleration;
    public float lenience;
    public float sens;
    float speed = 0;

    void start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        string[] points = data.Split(',');


        // locations
        float x = float.Parse(points[0])*sens;
        float y = float.Parse(points[1])*sens;

        Vector3 target = new Vector3(x,y,transform.position.z);
        Vector3 direction = target-transform.position;
        float distance = new Vector3(x-transform.position.x,y-transform.position.x, 0).magnitude;
        
        
        if (distance < lenience)
        {
            speed = 0;
        }
        else if (distance <=  Math.Pow(speed, 2)/(2*acceleration))
        {
            speed -= acceleration*Time.deltaTime;
        }
        else if (distance > Math.Pow(speed, 2)/(2*acceleration))
        {
            speed += acceleration*Time.deltaTime;
        }
        else
        {
            Debug.Log("Oh");
        }
        transform.position += direction*speed*Time.deltaTime;
        // transform.position = new Vector3((float) Math.Round(transform.position.x + Math.Sign(target.x-transform.position.x)* Math.Abs(speed)*Time.deltaTime, 2),
        //      transform.position.y,
        //      transform.position.z);

//new Vector3((float) Math.Round(transform.position.x + Math.Sign(target.x-transform.position.x)* Math.Abs(speed*direction.x)/direction.magnitude*Time.deltaTime, 2)
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraPostition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPostition.position;
    }
}

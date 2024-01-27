using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;


public class Spawner : MonoBehaviour
{
    public GameObject cylinder;

    public float rate;
    private float timer = 0;

    public Transform cameraPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > rate)
        {               
            Vector3 pos = new Vector3(cameraPosition.position.x, cameraPosition.position.y, 120); 
            Debug.Log(pos);       
            GameObject punch = Instantiate(cylinder, pos, Quaternion.identity);
            punch.transform.Rotate(90, 0, 0);
            punch.transform.localPosition = Vector3.zero;
            timer-= rate;
        }

        timer+=Time.deltaTime;
    }
}

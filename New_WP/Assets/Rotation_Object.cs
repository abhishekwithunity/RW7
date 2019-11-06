using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Object : MonoBehaviour
{
    [Range(0.5f, 10000.0f)]
    public float speed;//= 0.5f;
 
        
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.forward, speed);

    }
}

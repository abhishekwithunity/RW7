using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_New : MonoBehaviour
{
    public float time;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, time);
    }
}


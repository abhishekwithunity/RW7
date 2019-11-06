using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerLevel : MonoBehaviour
{
    public static BeginnerLevel instance;
    public GameObject InfoWindows1;
    public GameObject InfoWindows2;
   

    private void Awake()
    {
        instance = this;
        InfoWindows1.SetActive(false);
        InfoWindows2.SetActive(false);
         

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
}

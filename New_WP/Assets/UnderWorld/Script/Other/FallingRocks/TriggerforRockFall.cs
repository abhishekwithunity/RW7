using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerforRockFall : MonoBehaviour
{ 
    public FallingRocks fallrock;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("bridge");
            fallrock.Work();
            //other.gameObject.SendMessage("Work", SendMessageOptions.DontRequireReceiver);
        }

    }

}

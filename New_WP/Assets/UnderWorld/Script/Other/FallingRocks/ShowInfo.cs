using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class ShowInfo : MonoBehaviour
{
    public GameObject InfoBoxMine;
    public bool showtheimg;

    void Start()
    {
        InfoBoxMine.SetActive(false);
        showtheimg = false;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("show the image");
            InfoBoxMine.SetActive(true);
            showtheimg = true;
            // showimage.enabled = true;
            // fallrock.Work();
            //other.gameObject.SendMessage("Work", SendMessageOptions.DontRequireReceiver);
        }

    }
    
}

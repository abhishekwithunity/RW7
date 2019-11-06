using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info2_Trigger : MonoBehaviour
{

    public Rigidbody2D player;
    public GameObject infopol2;
    private bool startonce;
     

    private void Awake()
    {
        startonce = false;
    }
     public void showinfow1()

    {
        BeginnerLevel.instance.InfoWindows2.SetActive(true);
        Time.timeScale = 0;

    }

    public void closeinfow1()

    {
        BeginnerLevel.instance.InfoWindows2.SetActive(false);
        Time.timeScale = 1;

    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        //BeginnerLevel.instance.InfoWindows1.SetActive(true);
        //BeginnerLevel.instance.ShowInfoWindow1();
        if (startonce == false)
        {
            showinfow1();

            startonce = true;
        }
        
    }
}

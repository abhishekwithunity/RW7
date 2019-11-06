using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_LevelTrigger : MonoBehaviour
{
   
    public Rigidbody2D player;
    public GameObject infopol1;
    private bool startonce;

    //public GameObject infopol2;
    //public GameObject infopol3;
    //public GameObject infopol4;
    //public GameObject infopol5;
    //public GameObject infopol6;

    private void Awake()
    {
        startonce = false;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       // 
                    //.ShowInfoWindow1();

        //if (collision.gameObject.CompareTag("Info1"))
        //{
        //    Debug.Log("**************Info 1*************************");
        //    BeginnerLevel.instance.ShowInfoWindow1();
        //} 
  
    
        //if (other.gameObject.CompareTag("Info1"))
       
        if (collision.gameObject.CompareTag("Info1"))
        
        {
            Debug.Log("**************Info 1*************************");
            if (startonce == false)
            {
                showinfow1();

                startonce = true;
            }
            //    BeginnerLevel.instance.ShowInfoWindow1();
        }
    }




    public void showinfow1()

    {
        BeginnerLevel.instance.InfoWindows1.SetActive(true);
            Time.timeScale = 0;
           
    }

    public void closeinfow1()

    {
        BeginnerLevel.instance.InfoWindows1.SetActive(false);
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
        if (other.gameObject.CompareTag("Info1"))
        {
            Debug.Log("**************Info 1*************************");

            //    BeginnerLevel.instance.ShowInfoWindow1();
        }
        //if (other.gameObject.CompareTag("Info2"))
        //{
        //    BeginnerLevel.instance.ShowInfoWindow2();
        //}
        //if (other.gameObject.CompareTag("Info3"))
        //{
        //    BeginnerLevel.instance.ShowInfoWindow3();
        //}
        //if (other.gameObject.CompareTag("Info4"))
        //{
        //    BeginnerLevel.instance.ShowInfoWindow4();
        //}
        //if (other.gameObject.CompareTag("Info5"))
        //{
        //    BeginnerLevel.instance.ShowInfoWindow5();
        //}
        //if (other.gameObject.CompareTag("Info6"))
        //{
        //    BeginnerLevel.instance.ShowInfoWindow6();
        //}


    }
}

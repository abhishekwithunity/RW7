using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthSlider : MonoBehaviour
{
    public Image healthbar;
    float maxhealth = 15f;
    public int healthnow;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        //healthbar = GetComponent<Image>();

        health = maxhealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = 50f;
        //healthnow;
        //healthbar.fillAmount = health / maxhealth;
    }
}

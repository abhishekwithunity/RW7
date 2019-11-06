using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_enemy : MonoBehaviour
{
    public float sub_speed;
    public float sub_stoppingdistance, sub_retreatdistance;
    public Transform Player;

    public GameObject sub_projectile;
    public float timebetweenshots;
    public float starttimebetweenshots;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position,Player.position)>sub_stoppingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,Player.position,sub_speed*Time.deltaTime);

        }

        else if (Vector2.Distance(transform.position, Player.position) < sub_stoppingdistance && Vector2.Distance(transform.position, Player.position) > sub_retreatdistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Player.position) < sub_retreatdistance)
        {
          //  transform.rotation = new Vector3(transform.rotation.x, -transform.rotation.y, transform.rotation.z);
            transform.rotation = Quaternion.Euler(0,-180,0);
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -sub_speed * Time.deltaTime);
        }



        if (timebetweenshots<=0)
        {
            Instantiate(sub_projectile,transform.position,Quaternion.identity);
            timebetweenshots = starttimebetweenshots;
        }else
        {
            timebetweenshots -= Time.deltaTime;
        }
    }
}

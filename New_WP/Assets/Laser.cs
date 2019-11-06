using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject endpoint;
    public GameObject startpoint;
    private LineRenderer _lineRenderer;
    // Use this for initialization
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetWidth(0.2f, .2f);
    }

    //....
    // Update is called once per frame

    void Update()
    {

        _lineRenderer.SetPosition(0,startpoint.transform.position);
        _lineRenderer.SetPosition(1, endpoint.transform.position);

        //    _lineRenderer.SetPosition(0, transform.position);
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        //    if (hit.collider)
        //    {
        //        _lineRenderer.SetPosition(1, new Vector3(hit.point.x, hit.point.y, transform.position.z));
        //    }
        //    else
        //    {
        //        _lineRenderer.SetPosition(1, transform.up * 2000);
        //    }
        //}
    }
}

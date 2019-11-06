using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezFollower : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;
    private int routetogo;
    private float tparam;
    private Vector2 eneposition;
    //[Range(0.01f,10.0f)]
    public float speedmodifier = 0.5f;
    private bool coroutineallowed;



    // Start is called before the first frame update
    void Start()
    {
        routetogo = 0;
        tparam = 0f;
        speedmodifier = 0.5f;
        coroutineallowed = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (coroutineallowed)
            StartCoroutine(Gobythisroute(routetogo));
    }
    private IEnumerator Gobythisroute(int routenumber)
    {
        coroutineallowed = false;

        Vector2 p0 = routes[routenumber].GetChild(0).position;
        Vector2 p1 = routes[routenumber].GetChild(1).position;
        Vector2 p2 = routes[routenumber].GetChild(2).position;
        Vector2 p3 = routes[routenumber].GetChild(3).position;
        while (tparam < 1)
        {
            tparam += Time.deltaTime * speedmodifier;
            eneposition = Mathf.Pow(1 - tparam, 3) * p0 + 3 * Mathf.Pow(1 - tparam, 2) * tparam * p1 + 3 * (1 - tparam) * Mathf.Pow(tparam, 2) * p2 +
                             Mathf.Pow(tparam, 3) * p3;
            transform.position = eneposition;
            yield return new WaitForEndOfFrame();

        }
        tparam = 0f;
        routetogo += 1;
        if (routetogo > routes.Length - 1)
            routetogo = 0;
        coroutineallowed = true;
    }
}
